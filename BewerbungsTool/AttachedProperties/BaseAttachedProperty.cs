using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bewerbungstool.AttachedProperties
{
    public abstract class BaseAttachedProperty<Parent, Property> where Parent : BaseAttachedProperty<Parent, Property>, new()
    {

        #region Public Events 

        /// <summary>
        /// Fired when the value changes
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) =>
        {

        };
        #endregion

        #region Public Properies

        /// <summary>
        /// Singleton instance of our parent class
        /// </summary>

        public static Parent Instance { get; private set; } = new Parent();



        #endregion

        #region Attached Property Definitions


        /// <summary>
        /// The attached property for this class
        /// </summary>

        public static readonly DependencyProperty ValueProprty = DependencyProperty.RegisterAttached("Value",
            typeof(Property), typeof(BaseAttachedProperty<Parent, Property>)
            , new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));


        /// <summary>
        /// The callback event when the <see cref="ValueProprty"/> is changed
        /// </summary>
        /// <param name="d">the UI element that had its propery changed</param>
        /// <param name="e">the arguments for the event </param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //Call the Parent function
            Instance.OnValueChanged(d, e);

            //Call event listeners
            Instance.ValueChanged(d, e);
        }

        /// <summary>
        /// Gets the attached property
        /// </summary>
        /// <param name="d">The element to get the property from</param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProprty);


        /// <summary>
        /// Sets the attached Property
        /// </summary>
        /// <param name="d">The element to get the property from</param>
        /// <param name="property">The value to set the property to</param>
        public static void SetValue(DependencyObject d, Property property) => d.SetValue(ValueProprty, property);


        #endregion

        #region Event Methods

        /// <summary>
        /// The method that is called when any attached property of this type is changed
        /// </summary>
        /// <param name="sender">The UI elemt that this property was changed for</param>
        /// <param name="e">The arguments for this events </param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }

        #endregion



    }



}