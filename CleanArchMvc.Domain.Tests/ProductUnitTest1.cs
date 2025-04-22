using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create product with valid Parameters")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 10.99m, 2, "image.png");
            action.Should()
                  .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create product with invalid id")]
        public void CreateProduct_WithNegativeId_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 10.99m, 2, "image.png");
            action.Should()
                  .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid id.");
        }

        [Fact(DisplayName = "Create product with invalid name")]
        public void CreateProduct_WithShortName_DomainExceptionInvalidName()
        {
            Action action = () => new Product("Pr", "Product Description", 10.99m, 2, "image.png");
            action.Should()
                  .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid name. Name must have at least 3 characters");
        }

        [Fact(DisplayName = "Create product with null name")]
        public void CreateProduct_WithNullName_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, null, "Product Description", 10.99m, 2, "image.png");
            action.Should()
                  .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create product with long image name")]
        public void CreateProduct_WithLongImageName_DomainExceptionInvalidImage()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 10.99m, 2, new string('a', 251));
            action.Should()
                  .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid image. Image must have at most 250 characters");
        }

        [Fact(DisplayName = "Create product with null imagem")]
        public void CreateProduct_WithNullImage_DomainExceptionInvalidImage()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 10.99m, 2, null);
            action.Should()
                  .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create product with null imagem NullReferenceException")]
        public void CreateProduct_WithEmptyImage_NullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 10.99m, 2, null);
            action.Should()
                  .NotThrow<NullReferenceException>();
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_WithNegativeStock_DomainExceptionInvalidStock(int stock)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 10.99m, stock, "image.png");
            action.Should()
                  .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid stock. Stock must be greater than or equal to 0");
        }

        [Fact(DisplayName = "Create product with negative price")]
        public void CreateProduct_WithNegativePrice_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -10.99m, 2, "image.png");
            action.Should()
                  .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid price. Price must be greater than or equal to 0");
        }

        [Fact(DisplayName = "Create product with empty description")]
        public void CreateProduct_WithEmptyDescription_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Product Name", "", 10.99m, 2, "image.png");
            action.Should()
                  .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "Create product with short description")]
        public void CreateProduct_WithShortDescription_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Product Name", "Desc", 10.99m, 2, "image.png");
            action.Should()
                  .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid description. Description must have at least 5 characters");
        }

    }
}