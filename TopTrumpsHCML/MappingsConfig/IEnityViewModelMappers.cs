using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTrumpsHCML.Mappings
{
    public interface IEnityViewModelMappers<E, V> where E : class
                                                  where V : class
    {
        V MapEntityToViewModel(E entity);
        //E MapViewModelToEntity(V viewModel);
        IEnumerable<V> MapEntityToViewModel_List(IEnumerable<E> entityList);
    }
}
