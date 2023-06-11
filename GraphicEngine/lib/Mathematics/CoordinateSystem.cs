using Mathematics;
using Exceptions;

namespace Mathematics
{
    public class CoordinateSystem
    {
        private Point initial_point;
        private VectorSpace basis;
        public CoordinateSystem(Point initial_point, VectorSpace basis)
        {
            this.basis = basis;
            this.initial_point = initial_point;
        }

        public VectorSpace VectorSpace
        { 
            get { return basis; } 
        }
    }
}
