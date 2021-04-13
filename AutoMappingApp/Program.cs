using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMappingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Employee, EmployeeDTO>()
                    .ForMember(dest=>dest.Dept, acct=>acct.MapFrom(src=>src.Department))
                    .ForMember(dest=>dest.Name, acct=>acct.MapFrom(src=>src.FullName))
                    
                );
            //Creating the source object
            Employee emp = new Employee
            {
                FullName = "James",
                Salary = 20000,
                Address = "London",
                Department = "IT"
            };

            //Using automapper
            var mapper = new Mapper(config);
            var empDTO = mapper.Map<EmployeeDTO>(emp);
            //OR
            //var empDTO2 = mapper.Map<Employee, EmployeeDTO>(emp);
            Console.WriteLine("Name:" + empDTO.Name + ", Salary:" + empDTO.Salary + ", Address:" + empDTO.Address + ", Department:" + empDTO.Dept);
            Console.ReadLine();

        }
    }

    public class Employee
    {
        public string FullName { get; set; }
        public int Salary { get; set; }
        public Address address { get; set; }
        public string Department { get; set; }
    }

    public class EmployeeDTO
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public AddressDTO address { get; set; }
        public string Dept { get; set; }
    }

    public class Address
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
    public class AddressDTO
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

}
