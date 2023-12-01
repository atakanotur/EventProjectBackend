using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //Auth
        public static string AuthorizationDenied = "Başarısız Giriş!";
        public static string UserRegistered = "Kullanıcı kayıt oldu";
        public static string PasswordError = "Hatalı Şifre";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Böyle bir kullanıcı zaten var";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string AccessTokenCreated = "Access Token oluşturuldu";
        //MyEvent
        public static string EventNotCreated = "Etkinlik oluşturulamadı!";
        public static string EventCreated = "Etkinlik başarıyla oluşturuldu!";
        public static string EventNotUpdated = "Etkinlik güncellenemedi!";
        public static string EventUpdated = "Etkinlik başarıyla güncellendi!";
        public static string EventNotDeleted = "Etkinlik silinemedi!";
        public static string EventDeleted = "Etkinlik başarıyla silindi!";
        public static string EventNotFound = "Etkinlik bulunamadı";
        public static string EventFound = "Etkinlik bulundu!";
        public static string EventsNotListed = "Etkinlik oluşturulamadı!";
        public static string EventsListed = "Etkinlik oluşturuldu!";
        public static string EventAlreadyExists = "Bu etkinlik zaten var!";
        public static string EventDateIsInvalid = "Etkinlik tarihi geçersiz!";
        public static string JoinedTheEvent = "Etkinliğe katılındı!";
        public static string FailedToJoinEvent = "Etkinliğe katılma başarısız!";
        public static string LeavedTheEvent = "Etkinlikten çıkıldı!";
        public static string FailedToLeaveEvent = "Etkinlikten çıkma başarısız!";
        //MyEventParticipant
        public static string ParticipantLimitExceeded = "Katılımcı limiti aşıldı!";
        public static string ParticipantExist = "Böyle bir katılımcı zaten var!";
        public static string ParticipantUpdated = "Katılımcı başarıyla güncellendi!";
        public static string ParticipantNotUpdated = "Katılımcı güncellenemedi!";
        public static string ParticipantsListed = "Katılımcılar listelendi!";
        public static string ParticipantsNotListed = "Katılımcılar listenemedi!";
        public static string ParticipantDeleted = "Katılımcı başarıyla silindi!";
        public static string ParticipantNotDeleted = "Katılımcı silinemedi!";
        public static string ParticipantAdded = "Katılımcı başarıyla eklendi!";
        public static string ParticipantNotAdded = "Katılımcı eklenemedi!";
        public static string MyEventsIdsListed = "Event Id'leri listelendi!";
        public static string MyEventsIdsNotListed = "Event Id'leri listelenmedi!";
        //MyEventType
        public static string MyEventTypeUpdated = "Etkinlik türü başarıyla Güncellendi!";
        public static string MyEventTypeNotUpdated = "Etkinlik türü güncellenmedi!";
        public static string MyEventTypeListed = "Etkinlik türleri listelendi!";
        public static string MyEventTypeNotListed = "Etkinlik türleri listelenemedi!";
        public static string MyEventTypeDeleted = "Etkinlik türü başarıyla silindi!";
        public static string MyEventTypeNotDeleted = "Etkinlik türü silinemedi!";
        public static string MyEventTypeAdded = "Etkinlik türü başarıyla eklendi!";
        public static string MyEventTypeNotAdded = "Etkinlik türü eklenemedi!";
        public static string MyEventTypeExist = "Böyle bir etkinlik zaten var";
        public static string MyEventTypeNotExist = "Etkinlik türü bulunamadı!";
        //User
        public static string UserNotAdded = "Kullanıcı eklenemedi!";
        public static string UserAdded = "Kullanıcı başarıyla eklendi!";
        public static string UserNotUpdated = "Kullanıcı güncellenemedi!";
        public static string UserUpdated = "Kullanıcı başarıyla güncellendi!";
        public static string UserNotDeleted = "Kullanıcı silinemedi!";
        public static string UserDeleted = "Kullanıcı başarıyla silindi!";
        //--------------------------------
        public static string Message = "Message";

       
    }
}
