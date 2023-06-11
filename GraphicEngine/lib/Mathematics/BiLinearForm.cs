using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Exceptions;
using Mathematics;

namespace Mathematics
{
    public abstract class BiLinearForm
    {
        public static float Count(Matrix matrix, Vector vector_1, Vector vector_2)
        {
            if (vector_1.Size != matrix.Lines || vector_2.Size != matrix.Columns 
                || matrix.Lines != matrix.Columns) throw new EngineException.DimensionException();

            float result = 0;

            for (var i = 0; i < matrix.Lines; ++i)
                for (var j = 0; j < matrix.Columns; ++j)
                    result += matrix[i, j] * vector_1[i] * vector_2[j];

            return result;
        }
    }
}
