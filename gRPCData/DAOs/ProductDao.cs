﻿using Application.DaoInterfaces;
using Grpc.Core;
using Grpc.Net.Client;
using Sep;
using Shared.DTOs;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.DTOs.Update;
using Shared.Models;

namespace gRPCData.DAOs;

public class ProductDao: IProductDao
{
    public async Task<string> CreateAsync(ProductCreateDto alien)
    {
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
            
             
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateProductRequest(DTOFactory.toDtoProduct(alien));
        try
        {
            var response = client.createProduct(request);
            string createdFarmer = response.Resp;
            return createdFarmer;
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
            
             
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateGetProductByIdRequest(id);
        try
        {
            var response = client.getProductById(request);
            if (response.Product==null)
            {
                throw new Exception($"Product with id {id} was not found");
            }
            return DTOFactory.toProduct(response.Product);
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }
    }

    public async Task<IEnumerable<Product>> GetAsync(SearchProductDto searchParameters)
    {
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateAllProductsRequest(DTOFactory.ToProductSearchParameters(searchParameters));
        try
        {
            var response = client.getAllProducts(request);
            List<Product> products = new List<Product>();
            foreach (var item in response.AllProducts)
            {
                products.Add(DTOFactory.toProduct(item));
            }

            return products;
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }
    }

    public async Task<string> UpdateAsync(UpdateProductDto alien)
    {
        Product existing = await GetByIdAsync(alien.Id);
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        DtoProduct dto = new DtoProduct
        {
            FarmerId = existing.FarmerID,
            Id = existing.ProductID,
            Amount = alien.Amount,
            Availability = alien.Availability,
            ExpirationDate = alien.ExpirationDate,
            PickedDate = alien.PickedDate,
            Price = alien.Price,
            Type = alien.Type
        };
        
        
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateUpdateProductRequest(dto);
        try
        {
            var response = client.updateProduct(request);
            return response.Resp;
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }
    }
}