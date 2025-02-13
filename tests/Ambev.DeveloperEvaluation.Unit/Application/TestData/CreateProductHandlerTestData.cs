using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    public static class CreateProductHandlerTestData
    {
        private static readonly Faker<CreateProductCommand> CreateProductHandlerFaker = new Faker<CreateProductCommand>()
            .RuleFor(product => product.Title, f => f.Commerce.ProductName())
            .RuleFor(product => product.Price, f => f.Random.Decimal(1, 900))
            .RuleFor(product => product.Description, f => f.Commerce.ProductDescription())
            .RuleFor(product => product.Category, f => f.Commerce.Categories(1)[0])
            .RuleFor(product => product.Image, f => f.Image.Locale)
            .RuleFor(product => product.RatingRate, f => f.Random.Decimal(0, 5))
            .RuleFor(product => product.RatingCount, f => f.Random.Int(0, 500));

        public static CreateProductCommand GenerateValidCommand()
        {
            return CreateProductHandlerFaker.Generate();
        }

        public static CreateProductCommand GenerateInvalidCommand()
        {
            var createProductCommand = CreateProductHandlerFaker.Generate();
            createProductCommand.Title = "a";

            return createProductCommand;
        }
    }
}
