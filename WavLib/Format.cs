// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo

namespace WavLib;

/// <summary>
///     All the formats that are supported by RIFF WAVE
/// </summary>
public enum Format
{
    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    Unknown = 0x0000,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    Uncompressed = 0x0001,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    Adpcm = 0x0002,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    IeeeFloat = 0x0003,

    /// <summary>
    ///     Compaq Computer Corp.
    /// </summary>
    Vselp = 0x0004,

    /// <summary>
    ///     IBM Corporation
    /// </summary>
    IbmCvsd = 0x0005,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    Alaw = 0x0006,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    Mulaw = 0x0007,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    Dts = 0x0008,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    Drm = 0x0009,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    Wmavoice9 = 0x000A,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    Wmavoice10 = 0x000B,

    /// <summary>
    ///     OKI
    /// </summary>
    OkiAdpcm = 0x0010,

    /// <summary>
    ///     Intel Corporation
    /// </summary>
    DviAdpcm = 0x0011,

    /// <summary>
    ///     Intel Corporation
    /// </summary>
    ImaAdpcm = DviAdpcm,

    /// <summary>
    ///     Videologic
    /// </summary>
    MediaspaceAdpcm = 0x0012,

    /// <summary>
    ///     Sierra Semiconductor Corp
    /// </summary>
    SierraAdpcm = 0x0013,

    /// <summary>
    ///     Antex Electronics Corporation
    /// </summary>
    G723Adpcm = 0x0014,

    /// <summary>
    ///     DSP Solutions, Inc.
    /// </summary>
    Digistd = 0x0015,

    /// <summary>
    ///     DSP Solutions, Inc.
    /// </summary>
    Digifix = 0x0016,

    /// <summary>
    ///     Dialogic Corporation
    /// </summary>
    DialogicOkiAdpcm = 0x0017,

    /// <summary>
    ///     Media Vision, Inc.
    /// </summary>
    MediavisionAdpcm = 0x0018,

    /// <summary>
    ///     Hewlett Packard Company
    /// </summary>
    CuCodec = 0x0019,

    /// <summary>
    ///     Hewlett Packard Company
    /// </summary>
    HpDynVoice = 0x001A,

    /// <summary>
    ///     Yamaha Corporation of America
    /// </summary>
    YamahaAdpcm = 0x0020,

    /// <summary>
    ///     Speech Compression
    /// </summary>
    Sonarc = 0x0021,

    /// <summary>
    ///     DSP Group, Inc
    /// </summary>
    DspgroupTruespeech = 0x0022,

    /// <summary>
    ///     Echo Speech Corporation
    /// </summary>
    Echosc1 = 0x0023,

    /// <summary>
    ///     Virtual Music, Inc.
    /// </summary>
    AudiofileAf36 = 0x0024,

    /// <summary>
    ///     Audio Processing Technology
    /// </summary>
    Aptx = 0x0025,

    /// <summary>
    ///     Virtual Music, Inc.
    /// </summary>
    AudiofileAf10 = 0x0026,

    /// <summary>
    ///     Aculab plc
    /// </summary>
    Prosody1612 = 0x0027,

    /// <summary>
    ///     Merging Technologies S.A.
    /// </summary>
    Lrc = 0x0028,

    /// <summary>
    ///     Dolby Laboratories
    /// </summary>
    DolbyAc2 = 0x0030,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    Gsm610 = 0x0031,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    Msnaudio = 0x0032,

    /// <summary>
    ///     Antex Electronics Corporation
    /// </summary>
    AntexAdpcme = 0x0033,

    /// <summary>
    ///     Control Resources Limited
    /// </summary>
    ControlResVqlpc = 0x0034,

    /// <summary>
    ///     DSP Solutions, Inc.
    /// </summary>
    Digireal = 0x0035,

    /// <summary>
    ///     DSP Solutions, Inc.
    /// </summary>
    Digiadpcm = 0x0036,

    /// <summary>
    ///     Control Resources Limited
    /// </summary>
    ControlResCr10 = 0x0037,

    /// <summary>
    ///     Natural MicroSystems
    /// </summary>
    NmsVbxadpcm = 0x0038,

    /// <summary>
    ///     Crystal Semiconductor IMA ADPCM
    /// </summary>
    CsImaadpcm = 0x0039,

    /// <summary>
    ///     Echo Speech Corporation
    /// </summary>
    Echosc3 = 0x003A,

    /// <summary>
    ///     Rockwell International
    /// </summary>
    RockwellAdpcm = 0x003B,

    /// <summary>
    ///     Rockwell International
    /// </summary>
    RockwellDigitalk = 0x003C,

    /// <summary>
    ///     Xebec Multimedia Solutions Limited
    /// </summary>
    Xebec = 0x003D,

    /// <summary>
    ///     Antex Electronics Corporation
    /// </summary>
    G721Adpcm = 0x0040,

    /// <summary>
    ///     Antex Electronics Corporation
    /// </summary>
    G728Celp = 0x0041,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    Msg723 = 0x0042,

    /// <summary>
    ///     Intel Corp.
    /// </summary>
    IntelG7231 = 0x0043,

    /// <summary>
    ///     Intel Corp.
    /// </summary>
    IntelG729 = 0x0044,

    /// <summary>
    ///     Sharp
    /// </summary>
    SharpG726 = 0x0045,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    Mpeg = 0x0050,

    /// <summary>
    ///     InSoft, Inc.
    /// </summary>
    Rt24 = 0x0052,

    /// <summary>
    ///     InSoft, Inc.
    /// </summary>
    Pac = 0x0053,

    /// <summary>
    ///     ISO/MPEG Layer3 Format Tag
    /// </summary>
    Mpeglayer3 = 0x0055,

    /// <summary>
    ///     Lucent Technologies
    /// </summary>
    LucentG723 = 0x0059,

    /// <summary>
    ///     Cirrus Logic
    /// </summary>
    Cirrus = 0x0060,

    /// <summary>
    ///     ESS Technology
    /// </summary>
    Espcm = 0x0061,

    /// <summary>
    ///     Voxware Inc
    /// </summary>
    Voxware = 0x0062,

    /// <summary>
    ///     Canopus, co., Ltd.
    /// </summary>
    CanopusAtrac = 0x0063,

    /// <summary>
    ///     APICOM
    /// </summary>
    G726Adpcm = 0x0064,

    /// <summary>
    ///     APICOM
    /// </summary>
    G722Adpcm = 0x0065,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    Dsat = 0x0066,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    DsatDisplay = 0x0067,

    /// <summary>
    ///     Voxware Inc
    /// </summary>
    VoxwareByteAligned = 0x0069,

    /// <summary>
    ///     Voxware Inc
    /// </summary>
    VoxwareAc8 = 0x0070,

    /// <summary>
    ///     Voxware Inc
    /// </summary>
    VoxwareAc10 = 0x0071,

    /// <summary>
    ///     Voxware Inc
    /// </summary>
    VoxwareAc16 = 0x0072,

    /// <summary>
    ///     Voxware Inc
    /// </summary>
    VoxwareAc20 = 0x0073,

    /// <summary>
    ///     Voxware Inc
    /// </summary>
    VoxwareRt24 = 0x0074,

    /// <summary>
    ///     Voxware Inc
    /// </summary>
    VoxwareRt29 = 0x0075,

    /// <summary>
    ///     Voxware Inc
    /// </summary>
    VoxwareRt29Hw = 0x0076,

    /// <summary>
    ///     Voxware Inc
    /// </summary>
    VoxwareVr12 = 0x0077,

    /// <summary>
    ///     Voxware Inc
    /// </summary>
    VoxwareVr18 = 0x0078,

    /// <summary>
    ///     Voxware Inc
    /// </summary>
    VoxwareTq40 = 0x0079,

    /// <summary>
    ///     Voxware Inc
    /// </summary>
    VoxwareSc3 = 0x007A,

    /// <summary>
    ///     Voxware Inc
    /// </summary>
    VoxwareSc31 = 0x007B,

    /// <summary>
    ///     Softsound, Ltd.
    /// </summary>
    Softsound = 0x0080,

    /// <summary>
    ///     Voxware Inc
    /// </summary>
    VoxwareTq60 = 0x0081,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    Msrt24 = 0x0082,

    /// <summary>
    ///     AT&amp;T Labs, Inc.
    /// </summary>
    G729A = 0x0083,

    /// <summary>
    ///     Motion Pixels
    /// </summary>
    MviMvi2 = 0x0084,

    /// <summary>
    ///     DataFusion Systems (Pty) (Ltd)
    /// </summary>
    DfG726 = 0x0085,

    /// <summary>
    ///     DataFusion Systems (Pty) (Ltd)
    /// </summary>
    DfGsm610 = 0x0086,

    /// <summary>
    ///     Iterated Systems, Inc.
    /// </summary>
    Isiaudio = 0x0088,

    /// <summary>
    ///     OnLive! Technologies, Inc.
    /// </summary>
    Onlive = 0x0089,

    /// <summary>
    ///     Multitude Inc.
    /// </summary>
    MultitudeFtSx20 = 0x008A,

    /// <summary>
    ///     Infocom
    /// </summary>
    InfocomItsG721Adpcm = 0x008B,

    /// <summary>
    ///     Convedia Corp.
    /// </summary>
    ConvediaG729 = 0x008C,

    /// <summary>
    ///     Congruency Inc.
    /// </summary>
    Congruency = 0x008D,

    /// <summary>
    ///     Siemens Business Communications Sys
    /// </summary>
    Sbc24 = 0x0091,

    /// <summary>
    ///     Sonic Foundry
    /// </summary>
    DolbyAc3Spdif = 0x0092,

    /// <summary>
    ///     MediaSonic
    /// </summary>
    MediasonicG723 = 0x0093,

    /// <summary>
    ///     Aculab plc
    /// </summary>
    Prosody8Kbps = 0x0094,

    /// <summary>
    ///     ZyXEL Communications, Inc.
    /// </summary>
    ZyxelAdpcm = 0x0097,

    /// <summary>
    ///     Philips Speech Processing
    /// </summary>
    PhilipsLpcbb = 0x0098,

    /// <summary>
    ///     Studer Professional Audio AG
    /// </summary>
    Packed = 0x0099,

    /// <summary>
    ///     Malden Electronics Ltd.
    /// </summary>
    MaldenPhonytalk = 0x00A0,

    /// <summary>
    ///     Racal recorders
    /// </summary>
    RacalRecorderGsm = 0x00A1,

    /// <summary>
    ///     Racal recorders
    /// </summary>
    RacalRecorderG720A = 0x00A2,

    /// <summary>
    ///     Racal recorders
    /// </summary>
    RacalRecorderG7231 = 0x00A3,

    /// <summary>
    ///     Racal recorders
    /// </summary>
    RacalRecorderTetraAcelp = 0x00A4,

    /// <summary>
    ///     NEC Corp.
    /// </summary>
    NecAac = 0x00B0,

    /// <summary>
    ///     For Raw AAC, with format block AudioSpecificConfig() (as defined by MPEG 4), that follows WAVEFORMATEX
    /// </summary>
    RawAac1 = 0x00FF,

    /// <summary>
    ///     Rhetorex Inc.
    /// </summary>
    RhetorexAdpcm = 0x0100,

    /// <summary>
    ///     BeCubed Software Inc.
    /// </summary>
    Irat = 0x0101,

    /// <summary>
    ///     Vivo Software
    /// </summary>
    VivoG723 = 0x0111,

    /// <summary>
    ///     Vivo Software
    /// </summary>
    VivoSiren = 0x0112,

    /// <summary>
    ///     Philips Speech Processing
    /// </summary>
    PhilipsCelp = 0x0120,

    /// <summary>
    ///     Philips Speech Processing
    /// </summary>
    PhilipsGrundig = 0x0121,

    /// <summary>
    ///     Digital Equipment Corporation
    /// </summary>
    DigitalG723 = 0x0123,

    /// <summary>
    ///     Sanyo Electric Co., Ltd.
    /// </summary>
    SanyoLdAdpcm = 0x0125,

    /// <summary>
    ///     Sipro Lab Telecom Inc.
    /// </summary>
    SiprolabAceplnet = 0x0130,

    /// <summary>
    ///     Sipro Lab Telecom Inc.
    /// </summary>
    SiprolabAcelp4800 = 0x0131,

    /// <summary>
    ///     Sipro Lab Telecom Inc.
    /// </summary>
    SiprolabAcelp8V3 = 0x0132,

    /// <summary>
    ///     Sipro Lab Telecom Inc.
    /// </summary>
    SiprolabG729 = 0x0133,

    /// <summary>
    ///     Sipro Lab Telecom Inc.
    /// </summary>
    SiprolabG729A = 0x0134,

    /// <summary>
    ///     Sipro Lab Telecom Inc.
    /// </summary>
    SiprolabKelvin = 0x0135,

    /// <summary>
    ///     VoiceAge Corp.
    /// </summary>
    VoiceageAmr = 0x0136,

    /// <summary>
    ///     Dictaphone Corporation
    /// </summary>
    G726AdpcmAlt = 0x0140,

    /// <summary>
    ///     Dictaphone Corporation
    /// </summary>
    DictaphoneCelp68 = 0x0141,

    /// <summary>
    ///     Dictaphone Corporation
    /// </summary>
    DictaphoneCelp54 = 0x0142,

    /// <summary>
    ///     Qualcomm, Inc.
    /// </summary>
    QualcommPurevoice = 0x0150,

    /// <summary>
    ///     Qualcomm, Inc.
    /// </summary>
    QualcommHalfrate = 0x0151,

    /// <summary>
    ///     Ring Zero Systems, Inc.
    /// </summary>
    Tubgsm = 0x0155,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    Msaudio1 = 0x0160,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    Wmaudio2 = 0x0161,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    Wmaudio3 = 0x0162,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    WmaudioLossless = 0x0163,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    Wmaspdif = 0x0164,

    /// <summary>
    ///     Unisys Corp.
    /// </summary>
    UnisysNapAdpcm = 0x0170,

    /// <summary>
    ///     Unisys Corp.
    /// </summary>
    UnisysNapUlaw = 0x0171,

    /// <summary>
    ///     Unisys Corp.
    /// </summary>
    UnisysNapAlaw = 0x0172,

    /// <summary>
    ///     Unisys Corp.
    /// </summary>
    UnisysNap16K = 0x0173,

    /// <summary>
    ///     SyCom Technologies
    /// </summary>
    SycomAcmSyc008 = 0x0174,

    /// <summary>
    ///     SyCom Technologies
    /// </summary>
    SycomAcmSyc701G726L = 0x0175,

    /// <summary>
    ///     SyCom Technologies
    /// </summary>
    SycomAcmSyc701Celp54 = 0x0176,

    /// <summary>
    ///     SyCom Technologies
    /// </summary>
    SycomAcmSyc701Celp68 = 0x0177,

    /// <summary>
    ///     Knowledge Adventure, Inc.
    /// </summary>
    KnowledgeAdventureAdpcm = 0x0178,

    /// <summary>
    ///     Fraunhofer IIS
    /// </summary>
    FraunhoferIisMpeg2Aac = 0x0180,

    /// <summary>
    ///     Digital Theatre Systems, Inc.
    /// </summary>
    DtsDs = 0x0190,

    /// <summary>
    ///     Creative Labs, Inc
    /// </summary>
    CreativeAdpcm = 0x0200,

    /// <summary>
    ///     Creative Labs, Inc
    /// </summary>
    CreativeFastspeech8 = 0x0202,

    /// <summary>
    ///     Creative Labs, Inc
    /// </summary>
    CreativeFastspeech10 = 0x0203,

    /// <summary>
    ///     UHER informatic GmbH
    /// </summary>
    UherAdpcm = 0x0210,

    /// <summary>
    ///     Ulead Systems, Inc.
    /// </summary>
    UleadDvAudio = 0x0215,

    /// <summary>
    ///     Ulead Systems, Inc.
    /// </summary>
    UleadDvAudio1 = 0x0216,

    /// <summary>
    ///     Quarterdeck Corporation
    /// </summary>
    Quarterdeck = 0x0220,

    /// <summary>
    ///     I link Worldwide
    /// </summary>
    IlinkVc = 0x0230,

    /// <summary>
    ///     Aureal Semiconductor
    /// </summary>
    RawSport = 0x0240,

    /// <summary>
    ///     ESS Technology, Inc.
    /// </summary>
    EsstAc3 = 0x0241,

    /// <summary>
    ///     ToDo: Unknown
    /// </summary>
    GenericPassthru = 0x0249,

    /// <summary>
    ///     Interactive Products, Inc.
    /// </summary>
    IpiHsx = 0x0250,

    /// <summary>
    ///     Interactive Products, Inc.
    /// </summary>
    IpiRpelp = 0x0251,

    /// <summary>
    ///     Consistent Software
    /// </summary>
    Cs2 = 0x0260,

    /// <summary>
    ///     Sony Corp.
    /// </summary>
    SonyScx = 0x0270,

    /// <summary>
    ///     Sony Corp.
    /// </summary>
    SonyScy = 0x0271,

    /// <summary>
    ///     Sony Corp.
    /// </summary>
    SonyAtrac3 = 0x0272,

    /// <summary>
    ///     Sony Corp.
    /// </summary>
    SonySpc = 0x0273,

    /// <summary>
    ///     Telum Inc.
    /// </summary>
    TelumAudio = 0x0280,

    /// <summary>
    ///     Telum Inc.
    /// </summary>
    TelumIaAudio = 0x0281,

    /// <summary>
    ///     Norcom Electronics Corp.
    /// </summary>
    NorcomVoiceSystemsAdpcm = 0x0285,

    /// <summary>
    ///     Fujitsu Corp.
    /// </summary>
    FmTownsSnd = 0x0300,

    /// <summary>
    ///     Micronas Semiconductors, Inc.
    /// </summary>
    Micronas = 0x0350,

    /// <summary>
    ///     Micronas Semiconductors, Inc.
    /// </summary>
    MicronasCelp833 = 0x0351,

    /// <summary>
    ///     Brooktree Corporation
    /// </summary>
    BtvDigital = 0x0400,

    /// <summary>
    ///     Intel Corp.
    /// </summary>
    IntelMusicCoder = 0x0401,

    /// <summary>
    ///     Ligos
    /// </summary>
    IndeoAudio = 0x0402,

    /// <summary>
    ///     QDesign Corporation
    /// </summary>
    QdesignMusic = 0x0450,

    /// <summary>
    ///     On2 Technologies
    /// </summary>
    On2Vp7Audio = 0x0500,

    /// <summary>
    ///     On2 Technologies
    /// </summary>
    On2Vp6Audio = 0x0501,

    /// <summary>
    ///     AT&amp;T Labs, Inc.
    /// </summary>
    VmeVmpcm = 0x0680,

    /// <summary>
    ///     AT&amp;T Labs, Inc.
    /// </summary>
    Tpc = 0x0681,

    /// <summary>
    ///     Clearjump
    /// </summary>
    LightwaveLossless = 0x08AE,

    /// <summary>
    ///     Ing C. Olivetti &amp; C., S.p.A.
    /// </summary>
    Oligsm = 0x1000,

    /// <summary>
    ///     Ing C. Olivetti &amp; C., S.p.A.
    /// </summary>
    Oliadpcm = 0x1001,

    /// <summary>
    ///     Ing C. Olivetti &amp; C., S.p.A.
    /// </summary>
    Olicelp = 0x1002,

    /// <summary>
    ///     Ing C. Olivetti &amp; C., S.p.A.
    /// </summary>
    Olisbc = 0x1003,

    /// <summary>
    ///     Ing C. Olivetti &amp; C., S.p.A.
    /// </summary>
    Oliopr = 0x1004,

    /// <summary>
    ///     Lernout &amp; Hauspie
    /// </summary>
    LhCodec = 0x1100,

    /// <summary>
    ///     Lernout &amp; Hauspie
    /// </summary>
    LhCodecCelp = 0x1101,

    /// <summary>
    ///     Lernout &amp; Hauspie
    /// </summary>
    LhCodecSbc8 = 0x1102,

    /// <summary>
    ///     Lernout &amp; Hauspie
    /// </summary>
    LhCodecSbc12 = 0x1103,

    /// <summary>
    ///     Lernout &amp; Hauspie
    /// </summary>
    LhCodecSbc16 = 0x1104,

    /// <summary>
    ///     Norris Communications, Inc.
    /// </summary>
    Norris = 0x1400,

    /// <summary>
    ///     ISIAudio
    /// </summary>
    Isiaudio2 = 0x1401,

    /// <summary>
    ///     AT&amp;T Labs, Inc.
    /// </summary>
    SoundspaceMusicompress = 0x1500,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    MpegAdtsAac = 0x1600,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    MpegRawAac = 0x1601,

    /// <summary>
    ///     Microsoft Corporation (MPEG 4 Audio Transport Streams (LOAS/LATM)
    /// </summary>
    MpegLoas = 0x1602,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    NokiaMpegAdtsAac = 0x1608,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    NokiaMpegRawAac = 0x1609,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    VodafoneMpegAdtsAac = 0x160A,

    /// <summary>
    ///     Microsoft Corporation
    /// </summary>
    VodafoneMpegRawAac = 0x160B,

    /// <summary>
    ///     Microsoft Corporation (MPEG 2 AAC or MPEG 4 HE AAC v1/v2 streams with any payload (ADTS, ADIF, LOAS/LATM, RAW).
    ///     Format block includes MP4 AudioSpecificConfig() see HEAACWAVEFORMAT below
    /// </summary>
    MpegHeaac = 0x1610,

    /// <summary>
    ///     Voxware Inc.
    /// </summary>
    VoxwareRt24Speech = 0x181C,

    /// <summary>
    ///     Sonic Foundry
    /// </summary>
    SonicfoundryLossless = 0x1971,

    /// <summary>
    ///     Innings Telecom Inc.
    /// </summary>
    InningsTelecomAdpcm = 0x1979,

    /// <summary>
    ///     Lucent Technologies
    /// </summary>
    LucentSx8300P = 0x1C07,

    /// <summary>
    ///     Lucent Technologies
    /// </summary>
    LucentSx5363S = 0x1C0C,

    /// <summary>
    ///     CUSeeMe
    /// </summary>
    Cuseeme = 0x1F03,

    /// <summary>
    ///     NTCSoft
    /// </summary>
    NtcsoftAlf2CmAcm = 0x1FC4,

    /// <summary>
    ///     FAST Multimedia AG
    /// </summary>
    Dvm = 0x2000,

    /// <summary>
    ///     ToDo: Unknown
    /// </summary>
    Dts2 = 0x2001,

    /// <summary>
    ///     ToDo: Unknown
    /// </summary>
    Makeavis = 0x3313,

    /// <summary>
    ///     Divio, Inc.
    /// </summary>
    DivioMpeg4Aac = 0x4143,

    /// <summary>
    ///     Nokia
    /// </summary>
    NokiaAdaptiveMultirate = 0x4201,

    /// <summary>
    ///     Divio, Inc.
    /// </summary>
    DivioG726 = 0x4243,

    /// <summary>
    ///     LEAD Technologies
    /// </summary>
    LeadSpeech = 0x434C,

    /// <summary>
    ///     LEAD Technologies
    /// </summary>
    LeadVorbis = 0x564C,

    /// <summary>
    ///     xiph.org
    /// </summary>
    WavpackAudio = 0x5756,

    /// <summary>
    ///     Apple Lossless
    /// </summary>
    Alac = 0x6C61,

    /// <summary>
    ///     Ogg Vorbis
    /// </summary>
    OggVorbisMode1 = 0x674F,

    /// <summary>
    ///     Ogg Vorbis
    /// </summary>
    OggVorbisMode2 = 0x6750,

    /// <summary>
    ///     Ogg Vorbis
    /// </summary>
    OggVorbisMode3 = 0x6751,

    /// <summary>
    ///     Ogg Vorbis
    /// </summary>
    OggVorbisMode1Plus = 0x676F,

    /// <summary>
    ///     Ogg Vorbis
    /// </summary>
    OggVorbisMode2Plus = 0x6770,

    /// <summary>
    ///     Ogg Vorbis
    /// </summary>
    OggVorbisMode3Plus = 0x6771,

    /// <summary>
    ///     3COM Corp.
    /// </summary>
    ThreecomNbx = 0x7000,

    /// <summary>
    ///     Opus
    /// </summary>
    Opus = 0x704F,

    /// <summary>
    ///     ToDo: Unknown
    /// </summary>
    FaadAac = 0x706D,

    /// <summary>
    ///     AMR Narrowband
    /// </summary>
    AmrNb = 0x7361,

    /// <summary>
    ///     AMR Wideband
    /// </summary>
    AmrWb = 0x7362,

    /// <summary>
    ///     AMR Wideband Plus
    /// </summary>
    AmrWp = 0x7363,

    /// <summary>
    ///     GSMA/3GPP
    /// </summary>
    GsmAmrCbr = 0x7A21,

    /// <summary>
    ///     GSMA/3GPP
    /// </summary>
    GsmAmrVbrSid = 0x7A22,

    /// <summary>
    ///     Comverse Infosys
    /// </summary>
    ComverseInfosysG7231 = 0xA100,

    /// <summary>
    ///     Comverse Infosys
    /// </summary>
    ComverseInfosysAvqsbc = 0xA101,

    /// <summary>
    ///     Comverse Infosys
    /// </summary>
    ComverseInfosysSbc = 0xA102,

    /// <summary>
    ///     Symbol Technologies
    /// </summary>
    SymbolG729A = 0xA103,

    /// <summary>
    ///     VoiceAge Corp.
    /// </summary>
    VoiceageAmrWb = 0xA104,

    /// <summary>
    ///     Ingenient Technologies, Inc.
    /// </summary>
    IngenientG726 = 0xA105,

    /// <summary>
    ///     ISO/MPEG 4
    /// </summary>
    Mpeg4Aac = 0xA106,

    /// <summary>
    ///     Encore Software
    /// </summary>
    EncoreG726 = 0xA107,

    /// <summary>
    ///     ZOLL Medical Corp.
    /// </summary>
    ZollAsao = 0xA108,

    /// <summary>
    ///     xiph.org
    /// </summary>
    SpeexVoice = 0xA109,

    /// <summary>
    ///     Vianix LLC
    /// </summary>
    VianixMasc = 0xA10A,

    /// <summary>
    ///     Microsoft
    /// </summary>
    Wm9SpectrumAnalyzer = 0xA10B,

    /// <summary>
    ///     Microsoft
    /// </summary>
    WmfSpectrumAnayzer = 0xA10C,

    /// <summary>
    ///     ToDo: Unknown
    /// </summary>
    Gsm610Alt = 0xA10D,

    /// <summary>
    ///     ToDo: Unknown
    /// </summary>
    Gsm620 = 0xA10E,

    /// <summary>
    ///     ToDo: Unknown
    /// </summary>
    Gsm660 = 0xA10F,

    /// <summary>
    ///     ToDo: Unknown
    /// </summary>
    Gsm690 = 0xA110,

    /// <summary>
    ///     ToDo: Unknown
    /// </summary>
    GsmAdaptiveMultirateWb = 0xA111,

    /// <summary>
    ///     Polycom
    /// </summary>
    PolycomG722 = 0xA112,

    /// <summary>
    ///     Polycom
    /// </summary>
    PolycomG728 = 0xA113,

    /// <summary>
    ///     Polycom
    /// </summary>
    PolycomG729A = 0xA114,

    /// <summary>
    ///     Polycom
    /// </summary>
    PolycomSiren = 0xA115,

    /// <summary>
    ///     Global IP
    /// </summary>
    GlobalIpIlbc = 0xA116,

    /// <summary>
    ///     RadioTime
    /// </summary>
    RadiotimeTimeShiftRadio = 0xA117,

    /// <summary>
    ///     Nice Systems
    /// </summary>
    NiceAca = 0xA118,

    /// <summary>
    ///     Nice Systems
    /// </summary>
    NiceAdpcm = 0xA119,

    /// <summary>
    ///     Vocord Telecom
    /// </summary>
    VocordG721 = 0xA11A,

    /// <summary>
    ///     Vocord Telecom
    /// </summary>
    VocordG726 = 0xA11B,

    /// <summary>
    ///     Vocord Telecom
    /// </summary>
    VocordG7221 = 0xA11C,

    /// <summary>
    ///     Vocord Telecom
    /// </summary>
    VocordG728 = 0xA11D,

    /// <summary>
    ///     Vocord Telecom
    /// </summary>
    VocordG729 = 0xA11E,

    /// <summary>
    ///     Vocord Telecom
    /// </summary>
    VocordG729A = 0xA11F,

    /// <summary>
    ///     Vocord Telecom
    /// </summary>
    VocordG7231 = 0xA120,

    /// <summary>
    ///     Vocord Telecom
    /// </summary>
    VocordLbc = 0xA121,

    /// <summary>
    ///     Nice Systems
    /// </summary>
    NiceG728 = 0xA122,

    /// <summary>
    ///     France Telecom
    /// </summary>
    FraceTelecomG729 = 0xA123,

    /// <summary>
    ///     CODIAN
    /// </summary>
    Codian = 0xA124,

    /// <summary>
    ///     flac.sourceforge.net
    /// </summary>
    Flac = 0xF1AC,

    /// <summary>
    ///     Microsoft
    /// </summary>
    Extensible = 0xFFFE
}
