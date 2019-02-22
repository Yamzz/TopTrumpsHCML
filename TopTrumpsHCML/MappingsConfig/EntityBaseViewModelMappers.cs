using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopTrumpsHCML.Mappings
{
    public class EntityBaseViewModelMappers<E, V> : IEnityViewModelMappers<E, V>
                                                           where E : class
                                                           where V : class
    {
        public V MapEntityToViewModel(E entity)
        {
            var Vm = Mapper.Map<E, V>(entity);
            return Vm;
        }

        public IEnumerable<V> MapEntityToViewModel_List(IEnumerable<E> entityList)
        {
            var allVm = Mapper.Map<IEnumerable<E>, IEnumerable<V>>(entityList);
            return allVm.ToList();
        }

    }
}