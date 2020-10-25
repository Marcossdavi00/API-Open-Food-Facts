using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Domain.Entity
{
    public class DetailsServer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        private DateTime _ultimaAtualizacao;
        public string SituacaoDoServidor { get; set; }

        public DateTime UltimaAtualizacao
        {
            get { return _ultimaAtualizacao; }
            set { _ultimaAtualizacao = (value == null ? DateTime.Now : value); }
        }
    }
}
