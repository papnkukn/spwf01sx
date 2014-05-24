using System;

namespace Oxage
{
    public enum PinDirection
    {
        Input,
        Output
    }

    public enum PinInterrupt
    {
        Unknown = '?',
        Off = '0',
        RisingEdge = 'R',
        FallingEdge = 'F',
        BothEdges = 'B'
    }

    public enum SocketType
    {
        TCP = 't',
        UDP = 'u'
    }

    public enum CertificateType
    {
        /// <summary>
        /// Certificate authority chain
        /// </summary>
        CA,
        /// <summary>
        /// Client certificate
        /// </summary>
        Cert,
        /// <summary>
        /// Client private key
        /// </summary>
        Key,
        /// <summary>
        /// Diffie-Hellman parameters
        /// </summary>
        DHP,
    }

    public enum WifiState
    {
        /// <summary>
        /// Hardware Power Up
        /// </summary>
        HardwarePowerUp = 0,
        /// <summary>
        /// Hardware Failure
        /// </summary>
        HardwareFailure = 1,
        /// <summary>
        /// Radio Task Terminated by User
        /// </summary>
        UserTerminedRadioTask = 2,
        /// <summary>
        /// Radio Idle
        /// </summary>
        RadioIdle = 3,
        /// <summary>
        /// Scan in Progress
        /// </summary>
        ScanInProgress = 4,
        /// <summary>
        /// Scan Complete
        /// </summary>
        ScanComplete = 5,
        /// <summary>
        /// Join in Progress
        /// </summary>
        JoinInProgress = 6,
        /// <summary>
        /// Joined
        /// </summary>
        Joined = 7,
        /// <summary>
        /// Authenticated
        /// </summary>
        Authenticated = 8,
        /// <summary>
        /// Authentication Timeout
        /// </summary>
        AuthenticationTimeout = 9,
        /// <summary>
        /// Associated
        /// </summary>
        Associated = 10,
        /// <summary>
        /// Association Timeout
        /// </summary>
        AssociationTimeout = 11,
        /// <summary>
        /// 802.11 Handshake Complete
        /// </summary>
        HandshakeComplete = 12,
        /// <summary>
        /// Ready to transmit data, i.e. "Link Up"
        /// </summary>
        Ready = 13,
        /// <summary>
        /// Association lost to missed beacons
        /// </summary>
        AssociationLost = 14
    }

    public enum Wind
    {
        /// <summary>
        /// Console task is running and can accept AT commands
        /// </summary>
        ConsoleActive = 0,
        /// <summary>
        /// Initial powerup indication
        /// </summary>
        Poweron = 1,
        /// <summary>
        /// System reset is being asserted/triggered
        /// </summary>
        Reset = 2,
        /// <summary>
        /// Watchdog task initialized and running
        /// </summary>
        WatchdogRunning = 3,
        /// <summary>
        /// Selected heap allocation is too small for normal operation
        /// </summary>
        HeapTooSmall = 4,
        WifiRadioFailure = 5,
        WatchdogReset = 6,
        SysTickConfigure = 7,
        HardFault = 8,
        StackOverflow = 9,
        MallocFailed = 10,
        InitRadioFailure = 11,
        PowerSavingModeFailure = 12,
        CopyrightInfo = 13,
        WifiBssRegained = 14,
        WifiSignalLow = 15,
        WifiSignalOK = 16,
        WifiFirmwareUpgrade = 17,
        EncryptionKeyTypeUnknown = 18,
        BssJoinSucceed = 19,
        BssJoinFailed = 20,
        WifiScanning = 21,
        ScanNotAccepted = 22,
        ScanFailed = 23,
        WifiUp = 24,
        WifiAssociationSuccess = 25,
        WifiException = 31,
        WifiHardwareStarted = 32,
        WifiBssLost = 33,
        WifiUnhandledEvent = 34,
        ScanComplete = 35,
        UnhandledRadioIndication = 36,
        UnhandledRadioResponse = 37,
        WifiPowerDown = 38,
        BssFound = 39,
        WifiDeauthentication = 40,
        WifiDisassociation = 41,
        UnhandledManagementFrameSubtype = 42,
        UnhandledDataFrameSubtype = 43,
        UnhandledFrameType = 44,
        IllegalAuthentication = 45,
        WpaCreatePsk = 46,
        WpaTerminated = 49,
        WpaInitFailed = 50,
        WpaHandshakeComplete = 51,
        GpioChanged = 52,
        Wakeup = 53,
        ETF = 54,
        UserMessage = 99
    }

    public enum WifiSecurity
    {
        None,
        WPA,
        WPA2
    }
}
