using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Modèle.Documentation.Persistance
{
    /// <summary>
    /// Classe définissant le plante personnelle Data Transfer Objects
    /// </summary>
    [DataContract]
    public class MaPlanteDTO
    {
        /// <summary>
        /// Nom de la plante personnelle DTO
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Nom { get; set; }
        /// <summary>
        /// Nom Scientifique de la plante personnelle DTO
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string NomScientifique { get; set; }
        /// <summary>
        /// Lien de l'illustration d'une plante personnelle DTO
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Illustration { get; set; }
        /// <summary>
        /// Description d'une plante personnelle DTO
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Description { get; set; }
        /// <summary>
        /// Instruction d'entretient de la plante personnelle DTO
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Instruction { get; set; }
        /// <summary>
        /// Couleur de la plante personnelle DTO
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Couleurs Couleur { get; set; }
        /// <summary>
        /// Saison de la plante personnelle DTO
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Saisons Saison { get; set; }
        /// <summary>
        /// Note de la plante personnelle DTO
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Note Note { get; set; }

    }

    /// <summary>
    /// Classe définissant les différentes méthode pour le passage d'objet en DTO (Data Transfer Objects) ou en POCO (Plain old CLR objects)
    /// </summary>
    static class MaPlantesExtensions
    {
        /// <summary>
        /// Méthode permettant de transformer une MaPlanteDTO en MaPlante POCO
        /// </summary>
        /// <param name="dto">Plante personnelle en format DTO</param>
        /// <returns>Une plante personnelle</returns>
        public static MaPlante ToPOCO(this MaPlanteDTO dto)
            => new MaPlante(dto.Note.Description,dto.Nom, dto.NomScientifique, dto.Illustration, dto.Description, dto.Couleur, dto.Saison,dto.Instruction);

        /// <summary>
        /// Transforme une liste de plantes personnelles en DTO en une liste de plantes personnelles POCO
        /// </summary>
        /// <param name="dtos">Liste contenant les plantes personnelles en DTO</param>
        /// <returns>Une liste de plantes personnelles sous format POCO</returns>
        public static IEnumerable<MaPlante> ToPOCOs(this IEnumerable<MaPlanteDTO> dtos)
            => dtos.Select(dto => dto.ToPOCO());

        /// <summary>
        /// Méthode permettant de passer d'une plante personnelle en format POCO en plante personnelle en format DTO
        /// </summary>
        /// <param name="poco">Plante personnelle en format POCO</param>
        /// <returns>Une plante personnelle sous format DTO</returns>
        public static MaPlanteDTO ToDTO(this MaPlante poco)
        => new MaPlanteDTO
        {
            Note = poco.Note,
            Nom = poco.Nom,
            NomScientifique = poco.NomScientifique,
            Illustration = poco.Illustration,
            Description = poco.Description,
            Couleur = poco.Couleur,
            Saison = poco.Saison,
            Instruction= poco.Instruction
        };

        /// <summary>
        /// Méthode permettant de passer d'une liste de plantes personnelles en format POCO en liste plantes personnelles en format DTO
        /// </summary>
        /// <param name="pocos">Liste des plantes personnelles en format POCO</param>
        /// <returns>La liste de plante personnelles sous format POCO</returns>
        public static IEnumerable<MaPlanteDTO> ToDTOs(this IEnumerable<MaPlante> pocos)
            => pocos.Select(p => p.ToDTO());
    }
}
