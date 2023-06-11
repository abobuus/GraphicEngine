using Mathematics;

namespace Exceptions
{
    public abstract class EngineException
    {
        public class OutOfSizeException : ApplicationException
        {
            public OutOfSizeException() : base("Indexses exceed object sizes.") { }
        }

        public class DimensionException : ApplicationException
        {
            public DimensionException() : base("operation cannot be applied to objects of given dimensions.") { }
        }

        public class EmptyBasisException : ApplicationException
        {
            public EmptyBasisException() : base("Basis can not be empty.") { }
        }

        public class DifferentObjectsException : ApplicationException
        {
            public DifferentObjectsException() : base("This operation cannot be performed with these types of objects.") { }
        }

        public class ExceptionOfNonExistentProperty : ApplicationException
        {
            public ExceptionOfNonExistentProperty() : base("This property does not exist, the operation cannot be performed.") { }
        }

        public class PropertyTypeException : ApplicationException
        {
            public PropertyTypeException() : base("You cannot assign a value of this type to an entity property.") { }
        }

        public class NotAnExistingIdentifierException : ApplicationException
        {
            public NotAnExistingIdentifierException() : base("Accessing an entity by a non-existent identifier.") { }
        }

        public class NotAnExistingEntityException : ApplicationException
        {
            public NotAnExistingEntityException() : base("Access to non-existent entity.") { }
        }
    }
}
