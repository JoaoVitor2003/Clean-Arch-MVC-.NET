using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create category with valid Parameters")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                  .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create category with invalid id")]
        public void CreateCategory_WithNegativeId_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                  .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create category with invalid name")]
        public void CreateCategory_WithShortName_DomainExceptionInvalidName()
        {
            Action action = () => new Category("Ca");
            action.Should()
                  .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid name. Name must have at least 3 characters");
        }

        [Fact(DisplayName = "Create category with null name")]
        public void CreateCategory_WithNullName_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                  .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create category with empty name")]
        public void CreateCategory_WithEmptyName_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                  .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid name. Name is required");
        }
    }
}