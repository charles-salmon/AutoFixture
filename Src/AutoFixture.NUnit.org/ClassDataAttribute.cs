﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ploeh.AutoFixture.NUnit.org
{
    /// <summary>
    /// Provides a data source for a data theory, with the data coming from a class
    ///             which must implement IEnumerable&lt;object[]&gt;.
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ClassDataAttribute : DataAttribute
    {
        private readonly Type _class;

        /// <summary>
        /// Gets the type of the class that provides the data.
        /// 
        /// </summary>
        public Type Class
        {
            get
            {
                return _class;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ploeh.AutoFixture.NUnit.org.ClassDataAttribute"/> class.
        /// 
        /// </summary>
        /// <param name="class">The class that provides the data.</param>
        public ClassDataAttribute(Type @class)
        {
            _class = @class;
        }

        /// <inheritdoc/>
        public override IEnumerable<object[]> GetData(MethodInfo methodUnderTest, Type[] parameterTypes)
        {
            return (IEnumerable<object[]>)Activator.CreateInstance(_class);
        }
    }
}