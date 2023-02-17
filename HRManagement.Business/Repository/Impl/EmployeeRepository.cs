using HRManagement.Business.Context;
using HRManagement.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElasticsearchCRUD;
using ElasticsearchCRUD.Model.SearchModel;
using ElasticsearchCRUD.Model.SearchModel.Queries;
using HRManagement.Business.Repository.Impl;

namespace HRManagement.Business.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ModelDbContext _context;
        private readonly IElasticsearchMappingResolver _elasticsearchMappingResolver = new ElasticsearchMappingResolver();

        private readonly ElasticsearchContext _elasticsearchContext;

        public EmployeeRepository()
        {
            _context = new ModelDbContext();
            _elasticsearchMappingResolver.AddElasticSearchMappingForEntityType(typeof(Employee), new EmployeeToLowerExampleElasticsearchMapping());
            _elasticsearchContext = new ElasticsearchContext("http://localhost:9200/", new ElasticsearchSerializerConfiguration(new ElasticsearchMappingResolver(), true, false));
        }
    

        public async Task<Employee> Add(Employee o)
        {
            _context.Employees.Add(o);
            await _context.SaveChangesAsync();
            return o;
        }

        public async Task Delete(Employee o)
        {
            _context.Employees.Remove(o);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _context.Employees.Include("Address").Include("Holidays").Include("Appointments").ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Id == id.ToString());
        }

        public async Task<Employee> Update(Employee o)
        {
            var emp = _context.Employees.Update(o);
            await _context.SaveChangesAsync();
            return emp.Entity;
        }

        public async Task<int> Count()
        {
            return await _context.Employees.CountAsync();
        }

        public async Task<double> GetSalaryTotal()
        {
            return await _context.Employees.SumAsync(elt => elt.RawSalary);
        }

        public async Task<int> CountDeveloppers()
        {
            return await _context.Employees.Where(elt => elt.Fonction == "Developper").CountAsync();
        }

        public async Task<int> CountProjectManager()
        {
            return await _context.Employees.Where(elt => elt.Fonction == "ProjectManager").CountAsync();
        }

        public async Task<int> CountAdmin()
        {
            return await _context.Employees.Where(elt => elt.Fonction == "Admin").CountAsync();
        }

       

        public async Task SaveToElasticsearchEmployee(Employee employee)
        {
            _elasticsearchContext.AddUpdateDocument(employee, employee.Id);
            await _elasticsearchContext.SaveChangesAsync();                 
        }

        public async Task<IEnumerable<Employee>> GetElasticsearchEmployee(string term)
        {

            var names = "";
            if (term != null)
            {
                names = term.Replace("+", " OR *");
            }

            var search = new Search
            {
                From = 0,
                Size = 10,
                Query = new Query(new QueryStringQuery("string"))
            };

            IEnumerable<Employee> results;

            results = _elasticsearchContext.SearchAsync<Employee>("string").Result.PayloadResult.Hits.HitsResult.Select(t => t.Source);
            return results;
        }

        public IEnumerable<Employee> QueryString(string term)
        {
            var results = _elasticsearchContext.Search<Employee>(BuildQueryStringSearch(term));
            Console.WriteLine(results);
             
            return results.PayloadResult.Hits.HitsResult.Select(t => t.Source);           
        }

        private Search BuildQueryStringSearch(string term)
        {
            var names = "";
            if (term != null)
            {
                names = term.Replace("+", " OR *");
            }

            var search = new Search
            {
                Query = new Query(new QueryStringQuery(names + "*"))
            };

            return search;
        }
    }
}

