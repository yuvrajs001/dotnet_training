﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace codeChallangeADo
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CodeChallangeEntities : DbContext
    {
        public CodeChallangeEntities()
            : base("name=CodeChallangeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employee_Details> Employee_Details { get; set; }
    
        public virtual int AddEmployeeDetails(string empName, Nullable<decimal> empsal, string empType)
        {
            var empNameParameter = empName != null ?
                new ObjectParameter("EmpName", empName) :
                new ObjectParameter("EmpName", typeof(string));
    
            var empsalParameter = empsal.HasValue ?
                new ObjectParameter("Empsal", empsal) :
                new ObjectParameter("Empsal", typeof(decimal));
    
            var empTypeParameter = empType != null ?
                new ObjectParameter("EmpType", empType) :
                new ObjectParameter("EmpType", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddEmployeeDetails", empNameParameter, empsalParameter, empTypeParameter);
        }
    
        public virtual ObjectResult<ShowAllEmployees_Result> ShowAllEmployees()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ShowAllEmployees_Result>("ShowAllEmployees");
        }
    
        public virtual ObjectResult<ShowAllEmployee_Result> ShowAllEmployee()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ShowAllEmployee_Result>("ShowAllEmployee");
        }
    }
}