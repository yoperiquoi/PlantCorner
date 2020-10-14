
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Modèle.Documentation.Persistance
{
    /// <summary>
    /// Classe définissant le plante Data Transfer Objects
    /// </summary>
    [DataContract]
    public class PlanteDTO
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
    }

    /// <summary>
    /// Classe définissant les différentes méthode pour le passage de DTO (Data Transfer Objects) en POCO (Plain old CLR objects) ou inversement
    /// </summary>
    static class PlantesExtensions
    {
        /// <summary>
        /// Méthode permettant de transformer une PlanteDTO en Plante POCO
        /// </summary>
        /// <param name="dto">Plante en format DTO</param>
        /// <returns>Une plante</returns>
        public static Plante ToPOCO(this PlanteDTO dto)
            => new Plante(dto.Nom, dto.NomScientifique, dto.Illustration, dto.Description, dto.Couleur, dto.Saison, dto.Instruction);

        /// <summary>
        /// Transforme une liste de plante en DTO en une liste de plantes POCO
        /// </summary>
        /// <param name="dtos">Liste contenant les plantes en DTO</param>
        /// <returns>Une liste de plante sous format POCO</returns>
        public static IEnumerable<Plante> ToPOCOs(this IEnumerable<PlanteDTO> dtos)
            => dtos.Select(dto => dto.ToPOCO());

        /// <summary>
        /// Méthode permettant de passer d'une plante en format POCO en plante en format DTO
        /// </summary>
        /// <param name="poco">Plante en format POCO</param>
        /// <returns>Une plante sous format DTO</returns>
        public static PlanteDTO ToDTO(this Plante poco)
        => new PlanteDTO
        {
            Nom = poco.Nom,
            NomScientifique = poco.NomScientifique,
            Illustration = poco.Illustration,
            Description = poco.Description,
            Couleur = poco.Couleur,
            Saison = poco.Saison,
            Instruction = poco.Instruction
        };

        /// <summary>
        /// Méthode permettant de passer d'une liste de plantes en format POCO en liste plantes en format DTO
        /// </summary>
        /// <param name="pocos">Liste des plantes en format POCO</param>
        /// <returns>La liste de plante sous format POCO</returns>
        public static IEnumerable<PlanteDTO> ToDTOs(this IEnumerable<Plante> pocos)
            => pocos.Select(p => p.ToDTO());
    }
}
