//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license


// Reference:
// http://johngilliland.wordpress.com/2009/01/07/argument-validation-using-c-30-extension-methods/
// http://rogeralsing.com/2008/05/10/followup-how-to-validate-a-methods-arguments/


namespace dotNetExt.Validation
{
    public class ValidationArgument<T>
    {
        public ValidationArgument(string name, T value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; private set; }
        public T Value { get; private set; }

        public static implicit operator T(ValidationArgument<T> arg)
        {
            return arg.Value;
        }
    }
}
