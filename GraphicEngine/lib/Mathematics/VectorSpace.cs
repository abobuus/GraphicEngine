using Mathematics;
using Exceptions;

namespace Mathematics
{
    public class VectorSpace
    {
        private readonly Vector[] basis;

        public VectorSpace(params Vector[] vectors)
        {
            if (vectors.Length == 0)
                throw new EngineException.EmptyBasisException();

            int dimension = vectors[0].Size;
            basis = new Vector[vectors.Length];

            for (int i = 0; i < vectors.Length; ++i)
            {
                if (vectors[i].Size != dimension) 
                    throw new EngineException.DimensionException();

                basis[i] = vectors[i];
            }
        }

        public Vector[] Basis  
        {
            get { return basis; } 
        }

        public float ScalarProduct(Vector vector_1, Vector vector_2)
        {
            Matrix vector_1_transpose = new(vector_1);
            vector_1_transpose = vector_1_transpose.GetTranspose();

            return (vector_1_transpose * Matrix.Gram(basis) * vector_2)[0];
        }

        public Vector AsVector(Point point)
        {
            Vector result = new(basis.Length);

            for (int i = 0; i < basis.Length; ++i)
                result += point[i] * basis[i];

            return result;
        }
    }
}
