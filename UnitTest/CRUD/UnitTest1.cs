using System;
using System.Collections.Generic;
using WhereIsMyMoney.Models;
using WhereIsMyMoney.Services;
using Xunit;
using Moq;
using WhereIsMyMoney.Controllers;

namespace UnitTest.CRUD
{
    public class UnitTest1
    {
        private Mock<IExpensesRepository> _expensesRepository;
        private Mock<ICategoriesRepository> _categoryRepository;


        [Fact]
        public void DeleteExpense()
        {
            this.ResetMocks();
            
            var mockCategory = this.CreateCategory();
            _categoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(mockCategory);

            var expense = this.CreateExpense(mockCategory);
            _expensesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(expense);

            var expCont = new ExpensesController(_expensesRepository.Object, _categoryRepository.Object);
            expCont.Delete(It.IsAny<int>());
            _expensesRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void AddExpense()
        {
         this.ResetMocks();
         
         var mockCategory = this.CreateCategory();
         _categoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(mockCategory);

         var expense = this.CreateExpense(mockCategory);
         _expensesRepository.Setup(x => x.Add(It.IsAny<Expense>()));
         var expCont = new ExpensesController(_expensesRepository.Object, _categoryRepository.Object);
         expCont.Post(expense);
   
         _expensesRepository.Verify(x => x.Add(expense), Times.Once);

        }

        private void ResetMocks()
        {
            _expensesRepository = new Mock<IExpensesRepository>();
            _categoryRepository = new Mock<ICategoriesRepository>();
        }
        private Category CreateCategory()
        {
            return new Category
            {
                Id = 1,
                Name = "first category"
            };
        }

        private Expense CreateExpense(Category category)
        {
            return new Expense
            {
                Amount = 121.1,
                Category = category,
                CategoryId = 1,
                Date = "1999/12/12",
                Description = "mock description",
                Id = 1
            };
        }
    }
}