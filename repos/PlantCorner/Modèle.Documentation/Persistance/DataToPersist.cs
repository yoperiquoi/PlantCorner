using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Modèle.Documentation.Persistance
{
    /// <summary>
    /// Classe définissant le contenu de la persistance contenant dans le fichier XML et permettant la transformation des listes de plantes
    /// </summary>
    [DataContract]
    public class DataToPersist
    {
        [DataMember]
        public List<PlanteDTO> LesPlantes { get; set; } = new List<PlanteDTO>();
        
        [DataMember]
        public List<MaPlanteDTO> MesPlantes { get; set; } = new List<MaPlanteDTO>();
    }
}
