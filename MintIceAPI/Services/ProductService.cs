using AutoMapper;
using MintIceAPI.Entities;
using MintIceAPI.Helpers;
using MintIceAPI.Models;

namespace MintIceAPI.Services
{
    public class ProductService
    {
        private DataContext _context;
        private IMapper _mapper;
        public ProductService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.OrderBy(p => p.CreatedAt).ToList();
        }

        public IEnumerable<Product> GetAllByCreatedAt(DateTime date)
        {
            DateTime start = date.Date + new TimeSpan(0, 0, 0);
            DateTime stop = date.Date + new TimeSpan(23, 59, 59);
            return _context.Products.Where(p => p.CreatedAt >= start && p.CreatedAt <= stop).OrderBy(p => p.CreatedAt).ToList();
        }

        public IEnumerable<Product> GetAllByFiltering(DateTime dateFrom, DateTime dateTo)
        {
            dateFrom = dateFrom.Date + new TimeSpan(0, 0, 0);
            dateTo = dateTo.Date + new TimeSpan(23, 59, 59);
            return _context.Products.Where(p => (p.CreatedAt >= dateFrom) && (p.CreatedAt <= dateTo)).OrderBy(p => p.CreatedAt).ToList();
        }

        public void Create(ProductCreateRequest model)
        {
            // map model to new user object
            var product = _mapper.Map<Product>(model);

            // save user
            _context.Products.Add(product);
            _context.SaveChanges();
        }


        public Product GetById(int id)
        {
            return getProduct(id);
        }


        public void Update(int id, ProductUpdateRequest model)
        {
            var product = getProduct(id);

            // copy model to user and save
            _mapper.Map(model, product);
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = getProduct(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        // helper methods

        private Product getProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) throw new KeyNotFoundException("Product not found");
            return product;
        }
    }
}
