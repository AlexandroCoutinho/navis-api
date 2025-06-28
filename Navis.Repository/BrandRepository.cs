using MongoDB.Driver;
using Navis.Domain.Entities;
using Navis.Domain.Repository.Filters;
using Navis.Domain.Repository.Interfaces;
using Navis.Domain.Repository.PagedResult;
using System.Linq.Expressions;

namespace Navis.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMongoCollection<Brand> _mongoCollection;

        public BrandRepository()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017");
            _mongoDatabase = _mongoClient.GetDatabase("Navis");
            _mongoCollection = _mongoDatabase.GetCollection<Brand>("Brand");
        }

        public async Task<Brand> CreateAsync(Brand brand)
        {
            await _mongoCollection.InsertOneAsync(brand);
            var createdBrand = await ReadByIdAsync(brand.Id);

            if (brand == createdBrand)
            {
                var message = "referencias iguais";
            }
            else
            {
                var message = "referencias diferentes";
            }
            return createdBrand;
        }

        public async Task<Brand> ReadByIdAsync(string id)
        {
            var filter = Builders<Brand>.Filter.Eq(x => x.Id, id);
            var brand = await _mongoCollection.Find(filter).FirstOrDefaultAsync();
            return brand;
        }

        public async Task<PagedResult<Brand>> ReadPagedResultAsync(BrandFilter brandFilter)
        {
            PagedResult<Brand> pagedResultBrand = new PagedResult<Brand>();
            pagedResultBrand.PageSize = brandFilter.Paging.PageSize;
            pagedResultBrand.PageNumber = brandFilter.Paging.PageNumber;

            FilterDefinition<Brand> filterDefinition = GetFilterDefinition(brandFilter);
            SortDefinition<Brand> sorDefinition = GetSortDefinition<Brand>(brandFilter.Sorting);

            long totalItems = await _mongoCollection.CountDocumentsAsync(filterDefinition);
            pagedResultBrand.TotalItems = totalItems;


            var brands = await _mongoCollection
                .Find(filterDefinition)
                .Sort(sorDefinition)
                .Skip((brandFilter.Paging.PageNumber - 1) * brandFilter.Paging.PageSize)
                .Limit(brandFilter.Paging.PageSize)
                .ToListAsync();

            pagedResultBrand.Data = brands;

            return pagedResultBrand;
        }


        private FilterDefinition<Brand> GetFilterDefinition(BrandFilter brandFilter)
        {
            var filterBuilder = Builders<Brand>.Filter;
            var filterDefinition = filterBuilder.Empty;

            if (!string.IsNullOrWhiteSpace(brandFilter.Id))
            {
                filterDefinition &= filterBuilder.Eq(x => x.Id, brandFilter.Id);
            }

            if (!string.IsNullOrWhiteSpace(brandFilter.Name))
            {
                filterDefinition &= filterBuilder.Eq(x => x.Name, brandFilter.Name);
            }

            return filterDefinition;
        }

        public SortDefinition<T> GetSortDefinition<T>(Sorting sorting)
        {
            SortDefinition<T> sortDefinition = null;

            if (sorting != null && !string.IsNullOrWhiteSpace(sorting.SortBy))
            {
                var param = Expression.Parameter(typeof(T), "x");
                var property = Expression.PropertyOrField(param, sorting.SortBy);
                var lambda = Expression.Lambda(property, param);

                var method = sorting.Ascending ? "Ascending" : "Descending";

                var sortDefinitionBuilder = Builders<T>.Sort;

                var genericMethod = typeof(SortDefinitionBuilder<T>).GetMethod(method, new[] { typeof(Expression<Func<T, object>>) });

                if (genericMethod == null)
                {
                    throw new InvalidOperationException("Sort method not found");
                }

                var convertedLambda = Expression.Lambda<Func<T, object>>(Expression.Convert(lambda.Body, typeof(object)), param);

                sortDefinition = (SortDefinition<T>)genericMethod.Invoke(sortDefinitionBuilder, new object[] { convertedLambda })!;

            }

            return sortDefinition;
        }
    }
}
