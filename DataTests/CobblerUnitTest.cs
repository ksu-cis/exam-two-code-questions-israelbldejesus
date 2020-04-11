using System;
using ExamTwoCodeQuestions.Data;
using Xunit;
using System.ComponentModel;
using System.Collections.Generic;


namespace ExamTwoCodeQuestions.DataTests
{
    public class CobblerUnitTests
    {
        [Theory]
        [InlineData(FruitFilling.Cherry)]
        [InlineData(FruitFilling.Blueberry)]
        [InlineData(FruitFilling.Peach)]
        public void ShouldBeAbleToSetFruit(FruitFilling fruit)
        {
            var cobbler = new Cobbler();
            cobbler.Fruit = fruit;
            Assert.Equal(fruit, cobbler.Fruit);
        }

        [Fact]
        public void ShouldBeServedWithIceCreamByDefault()
        {
            var cobbler = new Cobbler();
            Assert.True(cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToSetWithIceCream(bool serveWithIceCream)
        {
            var cobbler = new Cobbler();
            cobbler.WithIceCream = serveWithIceCream;
            Assert.Equal(serveWithIceCream, cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true, 5.32)]
        [InlineData(false, 4.25)]
        public void PriceShouldReflectIceCream(bool serveWithIceCream, double price)
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = serveWithIceCream
            };
            Assert.Equal(price, cobbler.Price);
        }

        [Fact]
        public void DefaultSpecialInstructionsShouldBeEmpty()
        {
            var cobbler = new Cobbler();
            Assert.Empty(cobbler.SpecialInstructions);
        }

        [Fact]
        public void SpecialIstructionsShouldSpecifyHoldIceCream()
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = false
            };
            Assert.Collection<string>(cobbler.SpecialInstructions, instruction =>
            {
                Assert.Equal("Hold Ice Cream", instruction);
            });
        }

        [Fact]
        public void ShouldImplementIOrderItemInterface()
        {
            var cobbler = new Cobbler();
            Assert.IsAssignableFrom<IOrderItem>(cobbler);
        }

        /// <summary>
        /// Check that INotify gets implemented properly.
        /// </summary>
        [Fact]
        public void CobblerShouldImplementINotify()
        {
            var cobb = new Cobbler();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(cobb);
        }

        /// <summary>
        /// Check that INotify gets implemented properly.
        /// </summary>
        [Fact]
        public void FruitShouldImplementINotify()
        {
            var fruit = new Cobbler();
            fruit.Fruit = FruitFilling.Cherry;
            //fruit.Fruit = FruitFilling.Blueberry;
            Assert.PropertyChanged(fruit, "Fruit", () => {
                fruit.Fruit = FruitFilling.Peach;
                
            });
        }

        /// <summary>
        /// Check that INotify gets implemented properly.
        /// </summary>
        [Fact]
        public void WithIceCreamShouldImplementINotify()
        {
            var cream = new Cobbler();
            Assert.PropertyChanged(cream, "WithIceCream", () => {
                cream.WithIceCream = false;
            });

            //Assert.PropertyChanged(cream, "WithIceCream", new List<string>() { "Hold Ice Cream" }); ;
            }

            /// <summary>
            /// Check that INotify gets implemented properly.
            /// </summary>
            [Fact]
        public void SpecialInstructionsShouldImplementINotify()
        {
            var si = new Cobbler();
            Assert.PropertyChanged(si, "SpecialInstructions", () =>
            {
                si.SpecialInstructions.Equals(new List<string>());
            });
        }
    }
}
