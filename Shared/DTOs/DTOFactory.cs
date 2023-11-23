﻿using Shared.Models;
using Sep;
using Shared.DTOs.Create;
using Shared.DTOs.Search;

namespace Shared.DTOs;


public class DTOFactory
{
    //** Creating The Dtos **\\ 
    
    //** Users **\\ 

    public static DtoRegisterCustomer ToDtoCustomer(RegisterCustomerDto x)
    {
        var DtoRegisterCustomer = new DtoRegisterCustomer
        {
            PhoneNumber = x.Phonenumber,
            Password = x.Password,
            RepeatPassword = x.RepeatPassword,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Address = x.Address
        };
        return DtoRegisterCustomer;
    }
    public static DtoRegisterCustomer ToDtoCustomerForEditing(EditCustomerDto x)
    {
        var DtoRegisterCustomer = new DtoRegisterCustomer
        {
            PhoneNumber = x.PhoneNumber,
            Password = x.Password,
            RepeatPassword = x.RepeatPassword,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Address = x.Address
        };
        return DtoRegisterCustomer;
    }

    public static DtoRegisterFarmer ToDtoFarmer(RegisterFarmerDto x)
    {
        var DtoRegisterFarmer = new DtoRegisterFarmer
        {
            PhoneNumber = x.PhoneNumber,
            Password = x.Password,
            RepeatPassword = x.RepeatPassword,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Address = x.Address,
            Pesticides = x.Pesticides,
            FarmName = x.FarmName
        };
        return DtoRegisterFarmer;
    }

    public static DtoLogin toDtoLogin(LoginDto x)
    {
        var dtoLogin = new DtoLogin
        {
            Password = x.Password,
            PhoneNumber = x.Phonenumber
        };
        return dtoLogin;
    }

    public static Customer toCustomer(DtoCustomer x)
    {
        var customer = new Customer
        {
            Address = x.Address,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Phonenumber = x.PhoneNumber
        };
        return customer;
    }
    
    
    //** Products **\\ 
    
    public static DtoProduct toDtoProduct(ProductCreateDto x)
    {
        return new DtoProduct
        {
            Amount = x.Amount,
            ExpirationDate = x.ExpirationDate,
            FarmerId = x.FarmerID,
            PickedDate = x.PickedDate,
            Price = x.Price,
            Type = x.Type
        };
    }

    public static Product toProduct(DtoProduct dto)
    {
        return new Product
        {
            Amount = dto.Amount,
            Availability = dto.Availability,
            ExpirationDate = dto.ExpirationDate,
            FarmerID = dto.FarmerId,
            PickedDate = dto.PickedDate,
            Price = dto.Price,
            ProductID = dto.Id,
            Type = dto.Type
        };
    }

    public static ProductSearchParameters ToProductSearchParameters(SearchProductDto x)
    {
        return new ProductSearchParameters
        {
            Amount = x.Amount,
            Price = x.Price,
            Type = x.Type
        };
    }

    //** Creating the requests ** \\
    
    //** Users **\\ 
    
    public static loginRequest CreateLoginRequest(DtoLogin dto)
    {
        return new loginRequest
        {
            Login = dto
        };
    }

    public static registerCustomerRequest CreateRegisterCustomerRequest(DtoRegisterCustomer dto)
    {
        return new registerCustomerRequest
        {
            NewCustomer = dto
        };
    }

    public static registerFarmerRequest CreateRegisterFarmerRequest(DtoRegisterFarmer dto)
    {
        return new registerFarmerRequest
        {
            NewFarmer = dto
        };
    }

    public static getAllCustomersRequest CreateGetAllCustomersRequest()
    {
        return new getAllCustomersRequest();
    }

    public static getCustomerByPhoneRequest CreateGetCustomerByPhoneRequest(string phoneNumber)
    {
        return new getCustomerByPhoneRequest
        {
            CustomersPhone = phoneNumber
        };
    }

    public static editCustomerRequest CreateEditCustomerRequest(DtoRegisterCustomer dto)
    {
        return new editCustomerRequest
        {
            EditedCustomer = dto
        };
    }
    
    
    //** Products **\\ 

    public static createProductRequest CreateProductRequest(DtoProduct dto)
    {
        return new createProductRequest
        {
            NewProduct = dto
        };
    }

    public static getAllProductsRequest CreateAllProductsRequest(ProductSearchParameters dto)
    {
        return new getAllProductsRequest
        {
            Parameters = dto
        };
    }

    public static getProductByIdRequest CreateGetProductByIdRequest(int id)
    {
        return new getProductByIdRequest
        {
            Id = id
        };
    }
}