﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Linq;

public partial class AdventureWorksEntities : DbContext
{
    public AdventureWorksEntities()
        : base("name=AdventureWorksEntities")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
    public virtual DbSet<Address> Addresses { get; set; }
    public virtual DbSet<AddressType> AddressTypes { get; set; }
    public virtual DbSet<BusinessEntity> BusinessEntities { get; set; }
    public virtual DbSet<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
    public virtual DbSet<BusinessEntityContact> BusinessEntityContacts { get; set; }
    public virtual DbSet<ContactType> ContactTypes { get; set; }
    public virtual DbSet<CountryRegion> CountryRegions { get; set; }
    public virtual DbSet<EmailAddress> EmailAddresses { get; set; }
    public virtual DbSet<Password> Passwords { get; set; }
    public virtual DbSet<Person> People { get; set; }
    public virtual DbSet<PersonPhone> PersonPhones { get; set; }
    public virtual DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
    public virtual DbSet<StateProvince> StateProvinces { get; set; }
    public virtual DbSet<CountryRegionCurrency> CountryRegionCurrencies { get; set; }
    public virtual DbSet<CreditCard> CreditCards { get; set; }
    public virtual DbSet<Currency> Currencies { get; set; }
    public virtual DbSet<CurrencyRate> CurrencyRates { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<PersonCreditCard> PersonCreditCards { get; set; }
    public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
    public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
    public virtual DbSet<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; }
    public virtual DbSet<SalesPerson> SalesPersons { get; set; }
    public virtual DbSet<SalesPersonQuotaHistory> SalesPersonQuotaHistories { get; set; }
    public virtual DbSet<SalesReason> SalesReasons { get; set; }
    public virtual DbSet<SalesTaxRate> SalesTaxRates { get; set; }
    public virtual DbSet<SalesTerritory> SalesTerritories { get; set; }
    public virtual DbSet<SalesTerritoryHistory> SalesTerritoryHistories { get; set; }
    public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    public virtual DbSet<SpecialOffer> SpecialOffers { get; set; }
    public virtual DbSet<SpecialOfferProduct> SpecialOfferProducts { get; set; }
    public virtual DbSet<Store> Stores { get; set; }
    public virtual DbSet<vAdditionalContactInfo> vAdditionalContactInfoes { get; set; }
    public virtual DbSet<vStateProvinceCountryRegion> vStateProvinceCountryRegions { get; set; }
    public virtual DbSet<vIndividualCustomer> vIndividualCustomers { get; set; }
    public virtual DbSet<vPersonDemographic> vPersonDemographics { get; set; }
    public virtual DbSet<vSalesPerson> vSalesPersons { get; set; }
    public virtual DbSet<vSalesPersonSalesByFiscalYear> vSalesPersonSalesByFiscalYears { get; set; }
    public virtual DbSet<vStoreWithAddress> vStoreWithAddresses { get; set; }
    public virtual DbSet<vStoreWithContact> vStoreWithContacts { get; set; }
    public virtual DbSet<vStoreWithDemographic> vStoreWithDemographics { get; set; }

    [DbFunction("AdventureWorksEntities", "ufnGetContactInformation")]
    public virtual IQueryable<ufnGetContactInformation_Result> ufnGetContactInformation(Nullable<int> personID)
    {
        var personIDParameter = personID.HasValue ?
            new ObjectParameter("PersonID", personID) :
            new ObjectParameter("PersonID", typeof(int));

        return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ufnGetContactInformation_Result>("[AdventureWorksEntities].[ufnGetContactInformation](@PersonID)", personIDParameter);
    }

    public virtual ObjectResult<uspGetBillOfMaterials_Result> uspGetBillOfMaterials(Nullable<int> startProductID, Nullable<System.DateTime> checkDate)
    {
        var startProductIDParameter = startProductID.HasValue ?
            new ObjectParameter("StartProductID", startProductID) :
            new ObjectParameter("StartProductID", typeof(int));

        var checkDateParameter = checkDate.HasValue ?
            new ObjectParameter("CheckDate", checkDate) :
            new ObjectParameter("CheckDate", typeof(System.DateTime));

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetBillOfMaterials_Result>("uspGetBillOfMaterials", startProductIDParameter, checkDateParameter);
    }

    public virtual ObjectResult<uspGetEmployeeManagers_Result> uspGetEmployeeManagers(Nullable<int> businessEntityID)
    {
        var businessEntityIDParameter = businessEntityID.HasValue ?
            new ObjectParameter("BusinessEntityID", businessEntityID) :
            new ObjectParameter("BusinessEntityID", typeof(int));

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetEmployeeManagers_Result>("uspGetEmployeeManagers", businessEntityIDParameter);
    }

    public virtual ObjectResult<uspGetManagerEmployees_Result> uspGetManagerEmployees(Nullable<int> businessEntityID)
    {
        var businessEntityIDParameter = businessEntityID.HasValue ?
            new ObjectParameter("BusinessEntityID", businessEntityID) :
            new ObjectParameter("BusinessEntityID", typeof(int));

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetManagerEmployees_Result>("uspGetManagerEmployees", businessEntityIDParameter);
    }

    public virtual ObjectResult<uspGetWhereUsedProductID_Result> uspGetWhereUsedProductID(Nullable<int> startProductID, Nullable<System.DateTime> checkDate)
    {
        var startProductIDParameter = startProductID.HasValue ?
            new ObjectParameter("StartProductID", startProductID) :
            new ObjectParameter("StartProductID", typeof(int));

        var checkDateParameter = checkDate.HasValue ?
            new ObjectParameter("CheckDate", checkDate) :
            new ObjectParameter("CheckDate", typeof(System.DateTime));

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetWhereUsedProductID_Result>("uspGetWhereUsedProductID", startProductIDParameter, checkDateParameter);
    }

    public virtual int uspLogError(ObjectParameter errorLogID)
    {
        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspLogError", errorLogID);
    }

    public virtual int uspPrintError()
    {
        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspPrintError");
    }

    public virtual int uspSearchCandidateResumes(string searchString, Nullable<bool> useInflectional, Nullable<bool> useThesaurus, Nullable<int> language)
    {
        var searchStringParameter = searchString != null ?
            new ObjectParameter("searchString", searchString) :
            new ObjectParameter("searchString", typeof(string));

        var useInflectionalParameter = useInflectional.HasValue ?
            new ObjectParameter("useInflectional", useInflectional) :
            new ObjectParameter("useInflectional", typeof(bool));

        var useThesaurusParameter = useThesaurus.HasValue ?
            new ObjectParameter("useThesaurus", useThesaurus) :
            new ObjectParameter("useThesaurus", typeof(bool));

        var languageParameter = language.HasValue ?
            new ObjectParameter("language", language) :
            new ObjectParameter("language", typeof(int));

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspSearchCandidateResumes", searchStringParameter, useInflectionalParameter, useThesaurusParameter, languageParameter);
    }
}
