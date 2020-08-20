using System;

namespace CircleDock
{
    interface IPropertiesConverter
    {
        ObservableDictionary<Type, ObservableDictionary<string, object>> Properties { get; set; }
    }
}
