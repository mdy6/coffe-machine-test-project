using CoffeeMachineProject;
using CoffeMachineProject;
using System;
using Xunit;

namespace CoffeMachineProjectTest
{
    public class DrinkerMakerProtocolTest
    {
        [Fact]
        public void ConstructorEmptyTest()
        {
            var drinkMaker = new DrinkMaker();

            Assert.Equal(string.Empty, drinkMaker.Drink);
            Assert.Equal(string.Empty, drinkMaker.Message);
            Assert.Equal(string.Empty, drinkMaker.Instruction);
            Assert.False(drinkMaker.Stick);
            Assert.Equal(0, drinkMaker.SugarQuantity);
        }

        [Fact]
        public void ConstructorTest()
        {
            var instruction = "T:0:0";

            var drinkMaker = new DrinkMaker(instruction);

            Assert.Equal(DrinkType.Tea, drinkMaker.Drink);
            Assert.False(drinkMaker.Stick);
            Assert.Equal(0, drinkMaker.SugarQuantity);

            Assert.Equal(string.Empty, drinkMaker.Message);
            Assert.Equal(instruction, drinkMaker.Instruction);

            instruction = "H::";
            drinkMaker = new DrinkMaker(instruction);

            Assert.Equal(DrinkType.Chocolate, drinkMaker.Drink);
            Assert.False(drinkMaker.Stick);
            Assert.Equal(0, drinkMaker.SugarQuantity);

            Assert.Equal(string.Empty, drinkMaker.Message);
            Assert.Equal(instruction, drinkMaker.Instruction);

            instruction = "C:2:1";
            drinkMaker = new DrinkMaker(instruction);

            Assert.Equal(DrinkType.Coffee, drinkMaker.Drink);
            Assert.True(drinkMaker.Stick);
            Assert.Equal(2, drinkMaker.SugarQuantity);

            Assert.Equal(string.Empty, drinkMaker.Message);
            Assert.Equal(instruction, drinkMaker.Instruction);
        }

        [Fact]
        public void MessageTest()
        {
            var instruction = "M:message-content";
            var drinkMaker = new DrinkMaker(instruction);

            Assert.Equal(string.Empty, drinkMaker.Drink);
            Assert.False(drinkMaker.Stick);
            Assert.Equal(0, drinkMaker.SugarQuantity);

            Assert.Equal("message-content", drinkMaker.Message);
            Assert.Equal(instruction, drinkMaker.Instruction);
        }

        [Fact]
        public void ToStringTest()
        {
            var instruction = "M:message-content";
            var drinkMaker = new DrinkMaker(instruction);

            Assert.Equal("message-content", drinkMaker.ToString());

            instruction = "C:2:1";
            drinkMaker = new DrinkMaker(instruction);

            Assert.Equal("C:2:True", drinkMaker.ToString());
        }
    }
}