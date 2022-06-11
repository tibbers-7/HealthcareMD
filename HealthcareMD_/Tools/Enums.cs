/***********************************************************************
 * Module:  Gender.cs
 * Author:  Darko
 * Purpose: Definition of the Enum Model.Gender
 ***********************************************************************/

using System;

namespace HealthcareMD_
{
   public enum Gender
   {
      female,
      male
   }

    public enum RoomType
    {
        operatingRoom,
        intensiveCare,
        meetingRoom,
        waitingRoom,
        laboratory,
        restRoom,
        magacin,
        stockroom,
        toilet
    }

    public enum MarriageStatus
    {
        single,
        married,
        widow,
        divorced
    }
    public enum AccountType
    {
        sekretar,
        lekar,
        upravnik
    }

    public enum Status
    {
        accepted,
        denied,
        waiting,
        reported
    }

    public enum VacationStatus
    {
        passed,
        accepted,
        denied,
        waiting
    }

    public enum WeekDays
    {
        PON,
        UTO,
        SRE,
        ČET,
        PET,
        SUB,
        NED

    }
}