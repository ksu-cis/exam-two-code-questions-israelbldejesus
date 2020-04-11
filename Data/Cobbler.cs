/*
 * Author: Nathan Bean
 * Edited By: Israel B. Lopez De Jesus
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExamTwoCodeQuestions.Data
{
    public class Cobbler : IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// The fruit used in the cobbler
        /// </summary>
        public FruitFilling Fruit { get; set; }

        /// <summary>
        /// This event will be invoked when a property relating to the order is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// If the cobbler is served with ice cream
        /// </summary>
        public bool WithIceCream { get; set; } = true;

        /// <summary>
        /// Gets the price of the Cobbler
        /// </summary>
        public double Price
        {
            get
            {
                if (WithIceCream) return 5.32;
                else return 4.25;
            }
        }

        /// <summary>
        /// Gets any special instructions for preparing this dessert
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                if(WithIceCream) { return new List<string>(); }
                else { return new List<string>() { "Hold Ice Cream" }; }
            }
        }

        /// <summary>
        /// Invoke all events to ensure you don't miss anything
        /// </summary>
        public void InvokePropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Fruit"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WithIceCream"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
        }
    }
}
