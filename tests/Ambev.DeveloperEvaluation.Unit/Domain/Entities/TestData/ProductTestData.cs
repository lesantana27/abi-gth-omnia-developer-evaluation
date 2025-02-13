using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    public static class ProductTestData
    {
        private static readonly Faker<Product> ProductFaker = new Faker<Product>()
        .RuleFor(product => product.Title, f => f.Commerce.ProductName())
        .RuleFor(product => product.Price, f => f.Random.Decimal(1, 900))
        .RuleFor(product => product.Description, f => f.Commerce.ProductDescription())
        .RuleFor(product => product.Category, f => f.Commerce.Categories(1)[0])
        .RuleFor(product => product.Image, f => f.Image.Locale)
        .RuleFor(product => product.RatingRate, f => f.Random.Decimal(0, 5))
        .RuleFor(product => product.RatingCount, f => f.Random.Int(0, 500));

        public static Product GenerateValidProduct()
        {
            return ProductFaker.Generate();
        }

        public static Product GenerateInvalidTitleSmall()
        {
            var product = ProductFaker.Generate();
            product.Title = new Faker().Random.String(1, 2);

            return product;
        }

        public static Product GenerateInvalidTitleBig()
        {
            var product = ProductFaker.Generate();
            product.Title = new Faker().Random.String(51, 60);

            return product;
        }

        public static Product GenerateInvalidPrice()
        {
            var product = ProductFaker.Generate();
            product.Price = new Faker().Random.Decimal(-1000, -500);

            return product;
        }

        public static Product GenerateInvalidRatingRateNegative()
        {
            var product = ProductFaker.Generate();
            product.RatingRate = new Faker().Random.Decimal(-5, -1);

            return product;
        }

        public static Product GenerateInvalidRatingRatePositive()
        {
            var product = ProductFaker.Generate();
            product.RatingRate = new Faker().Random.Decimal(6, 10);

            return product;
        }

        public static Product GenerateInvalidRatingCountNegative()
        {
            var product = ProductFaker.Generate();
            product.RatingCount = new Faker().Random.Int(-5, -1);

            return product;

        }
    }
}
