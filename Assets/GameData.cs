using System;

[System.Serializable]
public class GameData
{
    public float _LOBBYtime = 5;
    public float _TREADMILLtime = 10;
    public float _BENCHtime = 30;
    public float _MACHINEtime = 60;
    public float _cash;
    public float _LOBBYcashToAdd = 20;
    public float _LOBBYlevel = 1;
    public float _TREADMILLcashToAdd = 50;
    public float _TREADMILLlevel = 1;
    public float _BENCHlevel = 1;
    public float _BENCHcashToAdd = 100;
    public float _MACHINElevel = 1;
    public float _MACHINEcashToAdd = 400;
    public float _acidCount;
    public float _creatineCount;
    public float _liquidCount;
    public bool _hasbench;
    public bool _hastread;
    public bool _hasmachine;
    public bool _haspharmacy;
    public string _lobbySpotSave;
    public string _treadSpotSave;
    public string _benchSpotSave;
    public string _machineSpotSave;
    public DateTime _logOffDate;
    public bool _gtg;

    public GameData(float LOBBYtime, float TREADMILLtime, float BENCHtime, float MACHINEtime, float cash, float LOBBYcashToAdd, float LOBBYlevel, float TREADMILLcashToAdd, float TREADMILLlevel
    ,float BENCHlevel
    ,float BENCHcashToAdd
    ,float MACHINElevel
    ,float MACHINEcashToAdd
    ,float acidCount
    ,float creatineCount
    ,float liquidCount
    ,bool hasbench
    ,bool hastread
    ,bool hasmachine
    ,bool haspharmacy
    ,string lobbySpotSave
    ,string treadSpotSave
    ,string benchSpotSave
    ,string machineSpotSave
    ,DateTime logOffDate
    ,bool gtg
    )

    {
        _LOBBYtime = LOBBYtime;
        _TREADMILLtime = TREADMILLtime;
        _BENCHtime = BENCHtime;
        _MACHINEtime = MACHINEtime;
        _cash = cash;
        _LOBBYcashToAdd = LOBBYcashToAdd;
        _LOBBYlevel = LOBBYlevel;
        _TREADMILLcashToAdd = TREADMILLcashToAdd;
        _TREADMILLlevel = TREADMILLlevel;
        _BENCHlevel = BENCHlevel;
        _BENCHcashToAdd = BENCHcashToAdd;
        _MACHINElevel = MACHINElevel;
        _MACHINEcashToAdd = MACHINEcashToAdd;
        _acidCount = acidCount;
        _creatineCount = creatineCount;
        _liquidCount = liquidCount;
        _hasbench = hasbench;
        _hastread = hastread;
        _hasmachine = hasmachine;
        _haspharmacy = haspharmacy;
        _lobbySpotSave = lobbySpotSave;
        _treadSpotSave = treadSpotSave;
        _benchSpotSave = benchSpotSave;
        _machineSpotSave = machineSpotSave;
        _logOffDate = logOffDate;
        _gtg = gtg;
    }
}