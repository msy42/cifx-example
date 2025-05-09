
/// <summary>
/// Summary description for Class1
/// </summary>
		//
		// TODO: Add constructor logic here
		//

        /**************************************************************************************
         
           Copyright (c) Hilscher GmbH. All Rights Reserved.
         
         **************************************************************************************
         
           Filename:
            $Workfile: cifXUser.h $
           Last Modification:
            $Author: Robert $
            $Modtime: 25.11.08 15:29 $
            $Revision: 9 $
           
           Targets:
             Win32/ANSI   : yes
             Win32/Unicode: yes (define _UNICODE)
             WinCE        : no
         
           Description:
            CIFx driver API definition file
               
           Changes:
         
             Version   Date        Author   Description
             ----------------------------------------------------------------------------------


        **************************************************************************************/

        /*****************************************************************************/
        /*! \addtogroup CIFX_DRIVER_API cifX Driver API implementation               */
        /*! \{                                                                       */
        /*****************************************************************************/

        /* ------------------------------------------------------------------------------------ */
        /*  global definitions                                                                  */
        /* ------------------------------------------------------------------------------------ */

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;

namespace cifXTest
{
    class cifXUser
    {
        private long CIFXHANDLE; 

        /* DPM memory validation */
        private const long CIFX_DPM_NO_MEMORY_ASSIGNED           = 0x0BAD0BADUL;
        private const long CIFX_DPM_INVALID_CONTENT              = 0xFFFFFFFFUL;

        /* CIFx global timeouts in milliseconds */                
        private const long CIFX_TO_WAIT_HW_RESET_ACTIVE          = 2000UL;
        private const long CIFX_TO_WAIT_HW                       = 2000UL;
        private const long CIFX_TO_WAIT_COS_CMD                  = 10UL;
        private const long CIFX_TO_WAIT_COS_ACK                  = 10UL;
        private const long CIFX_TO_SEND_PACKET                   = 5000UL;
        private const long CIFX_TO_1ST_PACKET                    = 1000UL;
        private const long CIFX_TO_CONT_PACKET                   = 1000UL;
        private const long CIFX_TO_LAST_PACKET                   = 1000UL;
        private const long CIFX_TO_FIRMWARE_START                = 10000UL;   

        /* Maximum channel number */
        private const long CIFX_MAX_NUMBER_OF_CHANNEL_DEFINITION = 8;
        private const long CIFX_MAX_NUMBER_OF_CHANNELS           = 6;
        private const long CIFX_NO_CHANNEL                       = 0xFFFFFFFF;

        /* Maximum file name length */
        private const long CIFX_MAX_FILE_NAME_LENGTH             = 260;
        private const long CIFX_MIN_FILE_NAME_LENGTH             = 5;

        /* The system device port number */
        private const long CIFX_SYSTEM_DEVICE                    = 0xFFFFFFFF;

        /* Information commands */
        private const long CIFX_INFO_CMD_SYSTEM_INFORMATION      = 1;
        private const long CIFX_INFO_CMD_SYSTEM_INFO_BLOCK       = 2;
        private const long CIFX_INFO_CMD_SYSTEM_CHANNEL_BLOCK    = 3;
        private const long CIFX_INFO_CMD_SYSTEM_CONTROL_BLOCK    = 4;
        private const long CIFX_INFO_CMD_SYSTEM_STATUS_BLOCK     = 5;

        /* General commands */
        private const long CIFX_CMD_READ_DATA                    = 1;
        private const long CIFX_CMD_WRITE_DATA                   = 2;

        /* HOST mode definition */
        private const long CIFX_HOST_STATE_NOT_READY             = 0;
        private const long CIFX_HOST_STATE_READY                 = 1;
        private const long CIFX_HOST_STATE_READ                  = 2;

        /* WATCHDOG commands*/
        private const long CIFX_WATCHDOG_STOP                    = 0;
        private const long CIFX_WATCHDOG_START                   = 1;

        /* Configuration Lock commands*/
        private const long CIFX_CONFIGURATION_UNLOCK             = 0;
        private const long CIFX_CONFIGURATION_LOCK               = 1;
        private const long CIFX_CONFIGURATION_GETLOCKSTATE       = 2;

        /* BUS state commands*/
        private const long CIFX_BUS_STATE_OFF                    = 0;
        private const long CIFX_BUS_STATE_ON                     = 1;
        private const long CIFX_BUS_STATE_GETSTATE               = 2;

        /* Memory pointer commands*/
        private const long CIFX_MEM_PTR_OPEN                     = 1;
        private const long CIFX_MEM_PTR_OPEN_USR                 = 2;
        private const long CIFX_MEM_PTR_CLOSE                    = 3;

        /* I/O area definition */
        private const long CIFX_IO_INPUT_AREA                    = 1;
        private const long CIFX_IO_OUTPUT_AREA                   = 2;

        /* Reset definitions */
        private const long CIFX_SYSTEMSTART                      = 1;
        private const long CIFX_CHANNELINIT                      = 2;


        /*****************************************************************************/
        /*! Structure definitions                                                    */
        /*****************************************************************************/
        private struct DRIVER_INFORMATIONtag
        {
          char            abDriverVersion = new char[32];                          /*!< Driver version                 */
          long            ulBoardCnt;                                   /*!< Number of available Boards     */
        } 
        public DRIVER_INFORMATIONtag DRIVER_INFORMATION = new DRIVER_INFORMATIONtag();

        private const long CIFx_MAX_INFO_NAME_LENTH              = 16;

        /*****************************************************************************/
        /*! Directory Information structure for enumerating directories              */
        /*****************************************************************************/
        private struct CIFX_DIRECTORYENTRYtag
        {
          CIFXHANDLE    hList;                                /*!< Handle from Enumeration function, do not touch */
          char          szFilename = new char[CIFx_MAX_INFO_NAME_LENTH]; /*!< Returned file name. */
          char bFiletype;                            /*!< Returned file type. */
          long ulFilesize;                           /*!< Returned file size. */

        } 
        public CIFX_DIRECTORYENTRYtag CIFX_DIRECTORYENTRY = new CIFX_DIRECTORYENTRYtag();

        /*****************************************************************************/
        /*! System Channel Information structure                                     */
        /*****************************************************************************/
        private struct SYSTEM_CHANNEL_SYSTEM_INFORMATIONtag
        {
          long   ulSystemError;                                /*!< Global system error            */
          long   ulDpmTotalSize;                               /*!< Total size dual-port memory in bytes */
          long   ulMBXSize;                                    /*!< System mailbox data size [Byte]*/
          long   ulDeviceNumber;                               /*!< Global device number           */
          long   ulSerialNumber;                               /*!< Global serial number           */
          long   ulOpenCnt;                                    /*!< Channel open counter           */
        } 
        public SYSTEM_CHANNEL_SYSTEM_INFORMATIONtag SYSTEM_CHANNEL_SYSTEM_INFORMATION = new SYSTEM_CHANNEL_SYSTEM_INFORMATIONtag();  

        /* System Channel: System Information Block */
        private struct SYSTEM_CHANNEL_SYSTEM_INFO_BLOCKtag
        {
          char  abCookie = new char[4];                                   /*!< 0x00 "netX" cookie */
          long  ulDpmTotalSize;                                /*!< 0x04 Total Size of the whole dual-port memory in bytes */
          long  ulDeviceNumber;                                /*!< 0x08 Device number */
          long  ulSerialNumber;                                /*!< 0x0C Serial number */
          short ausHwOptions[4];                               /*!< 0x10 Hardware options, xC port 0..3 */
          short usManufacturer;                                /*!< 0x18 Manufacturer Location */  
          short usProductionDate;                              /*!< 0x1A Date of production */
          long  ulLicenseFlags1;                               /*!< 0x1C License code flags 1 */
          long  ulLicenseFlags2;                               /*!< 0x20 License code flags 2 */
          short usNetxLicenseID;                               /*!< 0x24 netX license identification */
          short usNetxLicenseFlags;                            /*!< 0x26 netX license flags */
          short usDeviceClass;                                 /*!< 0x28 netX device class */
          char  bHwRevision;                                   /*!< 0x2A Hardware revision index */
          char  bHwCompatibility;                              /*!< 0x2B Hardware compatibility index */
          short ausReserved = new short[2];                                /*!< 0x2C:0x2F Reserved */
        } 
        public SYSTEM_CHANNEL_SYSTEM_INFO_BLOCKtag SYSTEM_CHANNEL_SYSTEM_INFO_BLOCK = new SYSTEM_CHANNEL_SYSTEM_INFO_BLOCKtag(); 

        /* System Channel: Channel Information Block */
        private const long CIFX_SYSTEM_CHANNEL_DEFAULT_INFO_BLOCK_SIZE  = 16 ;
        private struct SYSTEM_CHANNEL_CHANNEL_INFO_BLOCKtag
        {
          char  abInfoBlock = new char[CIFX_MAX_NUMBER_OF_CHANNEL_DEFINITION , CIFX_SYSTEM_CHANNEL_DEFAULT_INFO_BLOCK_SIZE];
        } 
        public SYSTEM_CHANNEL_CHANNEL_INFO_BLOCKtag SYSTEM_CHANNEL_CHANNEL_INFO_BLOCK = new SYSTEM_CHANNEL_CHANNEL_INFO_BLOCKtag();

        /* System Channel: System Control Block */
        private struct SYSTEM_CHANNEL_SYSTEM_CONTROL_BLOCKtag
        {
          long  ulSystemCommandCOS;                            /*!< 0x00 System channel change of state command */
          long  ulReserved;                                    /*!< 0x04 Reserved */
        } 
        public SYSTEM_CHANNEL_SYSTEM_CONTROL_BLOCKtag SYSTEM_CHANNEL_SYSTEM_CONTROL_BLOCK = new SYSTEM_CHANNEL_SYSTEM_CONTROL_BLOCKtag();

        /* System Channel: System Status Block */
        private struct SYSTEM_CHANNEL_SYSTEM_STATUS_BLOCKtag
        {
          long  ulSystemCOS;                                   /*!< 0x00 System channel change of state acknowledge */
          long  ulSystemStatus;                                /*!< 0x04 Actual system state */
          long  ulSystemError;                                 /*!< 0x08 Actual system error */  
          long  ulReserved1;                                   /*!< 0x0C reserved */
          long  ulTimeSinceStart;                              /*!< 0x10 time since start in seconds */
          short usCpuLoad;                                     /*!< 0x14 cpu load in 0,01% units (10000 => 100%) */
          char  abReserved = new char[42];                                /*!< 0x16:3F Reserved */
        } 
        public SYSTEM_CHANNEL_SYSTEM_STATUS_BLOCKtag SYSTEM_CHANNEL_SYSTEM_STATUS_BLOCK = new SYSTEM_CHANNEL_SYSTEM_STATUS_BLOCKtag();

        /*****************************************************************************/
        /*! Board Information structure                                              */
        /*****************************************************************************/
        private struct BOARD_INFORMATIONtag
        {
          long            lBoardError;                                  /*!< Global Board error. Set when device specific data must not be used */
          char            abBoardName   = new char[CIFx_MAX_INFO_NAME_LENTH];        /*!< Global board name              */
          char            abBoardAlias  = new char[CIFx_MAX_INFO_NAME_LENTH];       /*!< Global board alias name        */
          long   ulBoardID;                                    /*!< Unique board ID, driver created*/
          long   ulSystemError;                                /*!< System error                   */  
          long   ulPhysicalAddress;                            /*!< Physical memory address        */
          long   ulIrqNumber;                                  /*!< Hardware interrupt number      */
          char   bIrqEnabled;                                  /*!< Hardware interrupt enable flag */
          long   ulChannelCnt;                                 /*!< Number of available channels   */
          long   ulDpmTotalSize;                               /*!< Dual-Port memory size in bytes */
          SYSTEM_CHANNEL_SYSTEM_INFO_BLOCK tSystemInfo;                 /*!< System information             */ 
        } 
        public BOARD_INFORMATIONtag BOARD_INFORMATION = new BOARD_INFORMATIONtag();

        /*****************************************************************************/
        /*! Channel Information structure                                            */
        /*****************************************************************************/
        private struct CHANNEL_INFORMATIONtag
        {
          char            abBoardName = new char[CIFx_MAX_INFO_NAME_LENTH];        /*!< Global board name              */
          char            abBoardAlias= new char[CIFx_MAX_INFO_NAME_LENTH];       /*!< Global board alias name        */
          long   ulDeviceNumber;                               /*!< Global board device number     */
          long   ulSerialNumber;                               /*!< Global board serial number     */

          short  usFWMajor;                                    /*!< Major Version of Channel Firmware  */
          short  usFWMinor;                                    /*!< Minor Version of Channel Firmware  */
          short  usFWBuild;                                    /*!< Build number of Channel Firmware   */
          short  usFWRevision;                                 /*!< Revision of Channel Firmware       */
          char   bFWNameLength;                                /*!< Length  of FW Name                 */
          char   abFWName = new char[63];                                 /*!< Firmware Name                      */
          short  usFWYear;                                     /*!< Build Year of Firmware             */
          char   bFWMonth;                                     /*!< Build Month of Firmware (1..12)    */
          char   bFWDay;                                       /*!< Build Day of Firmware (1..31)      */

          long   ulChannelError;                               /*!< Channel error                  */
          long   ulOpenCnt;                                    /*!< Channel open counter           */
          long   ulPutPacketCnt;                               /*!< Number of put packet commands  */
          long   ulGetPacketCnt;                               /*!< Number of get packet commands  */
          long   ulMailboxSize;                                /*!< Mailbox packet size in bytes   */
          long   ulIOInAreaCnt;                                /*!< Number of IO IN areas          */
          long   ulIOOutAreaCnt;                               /*!< Number of IO OUT areas         */
          long   ulHskSize;                                    /*!< Size of the handshake cells    */  
          long   ulNetxFlags;                                  /*!< Actual netX state flags        */  
          long   ulHostFlags;                                  /*!< Actual Host flags              */
          long   ulHostCOSFlags;                               /*!< Actual Host COS flags          */
          long   ulDeviceCOSFlags;                             /*!< Actual Device COS flags        */
          
        } 
        public CHANNEL_INFORMATIONtag CHANNEL_INFORMATION = new CHANNEL_INFORMATIONtag();

        /*****************************************************************************/
        /*! IO Area Information structure                                            */
        /*****************************************************************************/
        private struct CHANNEL_IO_INFORMATIONtag
        {
          long ulTotalSize;                  /*!< Total IO area size in byte */
          long ulUsedSize;                   /*!< Used IO area size in byte */
          long ulIOMode;                     /*!< Exchange mode */  
        } 
        public CHANNEL_IO_INFORMATIONtag CHANNEL_IO_INFORMATION = new CHANNEL_IO_INFORMATIONtag();

        /*****************************************************************************/
        /*! Memory Information structure                                             */
        /*****************************************************************************/
        private struct MEMORY_INFORMATIONtag
        {
          void*                 pvMemoryID;           /*!< Identification of the memory area      */
          void**                ppvMemoryPtr;         /*!< Memory pointer                         */
          long*        pulMemorySize;        /*!< Complete size of the mapped memory     */
          long         ulChannel;            /*!< Requested channel number               */
          long*        pulChannelStartOffset;/*!< Start offset of the requested channel  */
          long*        pulChannelSize;       /*!< Memory size of the requested channel   */
        } 
        public MEMORY_INFORMATIONtag MEMORY_INFORMATION = new MEMORY_INFORMATIONtag();

        /*****************************************************************************/
        /*! PLC Memory Information structure                                         */
        /*****************************************************************************/
        private struct PLC_MEMORY_INFORMATIONtag
        {
          void*                 pvMemoryID;           /*!< Identification of the memory area      */
          void**                ppvMemoryPtr;         /*!< Memory pointer                         */
          long         ulAreaDefinition;     /*!< Input/output area                      */
          long         ulAreaNumber;         /*!< Area number                            */
          long*        pulIOAreaStartOffset; /*!< Start offset                           */
          long*        pulIOAreaSize;        /*!< Memory size                            */
        } 
        public PLC_MEMORY_INFORMATIONtag PLC_MEMORY_INFORMATION = new PLC_MEMORY_INFORMATIONtag();
         

        /***************************************************************************/
        /* Driver dependent information */

        private const long CIFX_MAX_PACKET_SIZE               = 1600;                  /*!< Maximum size of the RCX packet in bytes */
        private const long CIFX_PACKET_HEADER_SIZE            = 40;                    /*!< Maximum size of the RCX packet header in bytes */
        private const long CIFX_MAX_DATA_SIZE                 = (CIFX_MAX_PACKET_SIZE - CIFX_PACKET_HEADER_SIZE); /*!< Maximum RCX packet data size */

        private const CIFX_MSK_PACKET_ANSWER                  = 0x00000001;            /*!< Packet answer bit */

        /*****************************************************************************/
        /*! Packet header                                                            */
        /*****************************************************************************/
        private struct CIFX_PACKET_HEADERtag
        {
          long   ulDest;   /*!< destination of packet, process queue */ 
          long   ulSrc;    /*!< source of packet, process queue */
          long   ulDestId; /*!< destination reference of packet */
          long   ulSrcId;  /*!< source reference of packet */
          long   ulLen;    /*!< length of packet data without header */  
          long   ulId;     /*!< identification handle of sender */
          long   ulState;  /*!< status code of operation */
          long   ulCmd;    /*!< packet command defined in TLR_Commands.h */
          long   ulExt;    /*!< extension */
          long   ulRout;   /*!< router */
        } 
        public CIFX_PACKET_HEADERtag CIFX_PACKET_HEADER = new CIFX_PACKET_HEADERtag();   

        /*****************************************************************************/
        /*! Definition of the rcX Packet                                             */
        /*****************************************************************************/
        private struct CIFX_PACKETtag
        {
          CIFX_PACKET_HEADER  tHeader;                   /**! */
          char       abData = new char[CIFX_MAX_DATA_SIZE];
        } 
        public CIFX_PACKETtag CIFX_PACKET = new CIFX_PACKETtag;

        private const long CIFX_CALLBACK_ACTIVE   = 0;
        private const long CIFX_CALLBACK_FINISHED = 1;

        /*
        typedef void(*PFN_PROGRESS_CALLBACK)(unsigned long ulStep, unsigned long ulMaxStep, void* pvUser, char bFinished, long lError);
        typedef void(*PFN_RECV_PKT_CALLBACK)(CIFX_PACKET* ptRecvPkt, void* pvUser);
        */
        private const long DOWNLOAD_MODE_FIRMWARE    = 1;
        private const long DOWNLOAD_MODE_CONFIG      = 2;
        private const long DOWNLOAD_MODE_FILE        = 3;
        private const long DOWNLOAD_MODE_BOOTLOADER  = 4; /*!< Download bootloader update to target. */
        private const long DOWNLOAD_MODE_LICENSECODE = 5; /*!< License update code.                  */


        /***************************************************************************
        * API Functions
        ***************************************************************************/
        /*
        /* Global driver functions */
        [DLLImport("cifx32dll.dll", EntryPoint = "xDriverOpen")]
        private static extern long _xDriverOpen( CIFXHANDLE* phDriver);
        [DLLImport("cifx32dll.dll", EntryPoint = "xDriverClose")]
        private static extern long _xDriverClose( CIFXHANDLE  hDriver);
        [DLLImport("cifx32dll.dll", EntryPoint = "xDriverGetInformation")]
        private static extern long _xDriverGetInformation(  CIFXHANDLE  hDriver, 
                                                            long ulSize, 
                                                            void* pvDriverInfo);
        [DLLImport("cifx32dll.dll", EntryPoint = "xDriverGetErrorDescription")]
        private static extern _xDriverGetErrorDescription(  long lError, 
                                                            char* szBuffer, 
                                                            long ulBufferLen);
        [DLLImport("cifx32dll.dll", EntryPoint = "xDriverEnumBoards")]
        private static extern long _xDriverEnumBoards(  CIFXHANDLE   hDriver, 
                                                        long ulBoard, 
                                                        long ulSize, 
                                                        void* pvBoardInfo);
        [DLLImport("cifx32dll.dll", EntryPoint = "xDriverEnumChannels")]
        private static extern long _xDriverEnumChannels(    CIFXHANDLE  hDriver,
                                                            long ulBoard, 
                                                            long ulChannel, 
                                                            long ulSize, 
                                                            void* pvChannelInfo);
        [DLLImport("cifx32dll.dll", EntryPoint = "xDriverMemoryPointer")]
        private static extern long _xDriverMemoryPointer(   CIFXHANDLE  hDriver, 
                                                            long ulBoard, 
                                                            long ulCmd,
                                                            void* pvMemoryInfo);
        [DLLImport("cifx32dll.dll", EntryPoint = "xDriverRestartDevice")]
        private static extern long _xDriverRestartDevice(   CIFXHANDLE  hDriver, 
                                                            char* szBoardName,     
                                                            void* pvData);

        /* System device depending functions */
        [DLLImport("cifx32dll.dll", EntryPoint = "")]
        private static extern long _xSysdeviceOpen(     CIFXHANDLE  hDriver, 
                                                        char*   szBoard, 
                                                        CIFXHANDLE* phSysdevice);
        [DLLImport("cifx32dll.dll", EntryPoint = "xSysdeviceClose")]
        private static extern long _xSysdeviceClose(    CIFXHANDLE  hSysdevice);
        [DLLImport("cifx32dll.dll", EntryPoint = "xSysdeviceGetMBXState")]
        private static extern long _xSysdeviceGetMBXState(  CIFXHANDLE  hSysdevice, 
                                                            long* pulRecvPktCount, 
                                                            long* pulSendPktCount);
        [DLLImport("cifx32dll.dll", EntryPoint = "xSysdevicePutPacket")]
        private static extern long _xSysdevicePutPacket(    CIFXHANDLE  hSysdevice, 
                                                            CIFX_PACKET* ptSendPkt, 
                                                            long ulTimeout);
        [DLLImport("cifx32dll.dll", EntryPoint = "xSysdeviceGetPacket")]
        private static extern long _xSysdeviceGetPacket(    CIFXHANDLE  hSysdevice, 
                                                            long ulSize, 
                                                            CIFX_PACKET* ptRecvPkt, 
                                                            long ulTimeout);
        [DLLImport("cifx32dll.dll", EntryPoint = "xSysdeviceInfo")]
        private static extern long _xSysdeviceInfo( CIFXHANDLE  hSysdevice, 
                                                    long ulCmd, 
                                                    long ulSize, 
                                                    void* pvInfo);
        [DLLImport("cifx32dll.dll", EntryPoint = "xSysdeviceFindFirstFile")]
        private static extern long _xSysdeviceFindFirstFile(    CIFXHANDLE  hSysdevice, 
                                                                long ulChannel, 
                                                                CIFX_DIRECTORYENTRY* ptDirectoryInfo, 
                                                                PFN_RECV_PKT_CALLBACK pfnRecvPktCallback, 
                                                                void* pvUser);
        [DLLImport("cifx32dll.dll", EntryPoint = "xSysdeviceFindNextFile")]
        private static extern long _xSysdeviceFindNextFile( CIFXHANDLE  hSysdevice, 
                                                            long ulChannel, 
                                                            CIFX_DIRECTORYENTRY* ptDirectoryInfo, 
                                                            PFN_RECV_PKT_CALLBACK pfnRecvPktCallback, 
                                                            void* pvUser);
        [DLLImport("cifx32dll.dll", EntryPoint = "xSysdeviceDownload")]
        private static extern long _xSysdeviceDownload( CIFXHANDLE  hSysdevice, 
                                                        long ulChannel, 
                                                        long ulMode, 
                                                        char* pszFileName, 
                                                        char* pabFileData, 
                                                        long ulFileSize,
                                                        PFN_PROGRESS_CALLBACK pfnCallback, 
                                                        PFN_RECV_PKT_CALLBACK pfnRecvPktCallback, 
                                                        void* pvUser);
        [DLLImport("cifx32dll.dll", EntryPoint = "xSysdeviceUpload")]
        private static extern long _xSysdeviceUpload(   CIFXHANDLE  hSysdevice, 
                                                        long ulChannel, 
                                                        long ulMode, 
                                                        char* pszFileName, 
                                                        char* pabFileData, 
                                                        long* pulFileSize, 
                                                        PFN_PROGRESS_CALLBACK pfnCallback, 
                                                        PFN_RECV_PKT_CALLBACK pfnRecvPktCallback, 
                                                        void* pvUser);
        [DLLImport("cifx32dll.dll", EntryPoint = "xSysdeviceReset")]
        private static extern long _xSysdeviceReset(    CIFXHANDLE  hSysdevice, 
                                                        long ulTimeout);

        /* Channel depending functions */
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelOpen")]
        private static extern long _xChannelOpen(   CIFXHANDLE  hDriver,  
                                                    char* szBoard, 
                                                    long ulChannel, 
                                                    CIFXHANDLE* phChannel);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelClose")]
        private static extern long _xChannelClose(  CIFXHANDLE  hChannel);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelFindFirstFile")]
        private static extern long _xChannelFindFirstFile(  CIFXHANDLE  hChannel, 
                                                            CIFX_DIRECTORYENTRY* ptDirectoryInfo, 
                                                            PFN_RECV_PKT_CALLBACK pfnRecvPktCallback, 
                                                            void* pvUser);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelFindNextFile")]
        private static extern long _xChannelFindNextFile(   CIFXHANDLE  hChannel, 
                                                            CIFX_DIRECTORYENTRY* ptDirectoryInfo, 
                                                            PFN_RECV_PKT_CALLBACK pfnRecvPktCallback, 
                                                            void* pvUser);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelDownload")]
        private static extern long _xChannelDownload(   CIFXHANDLE  hChannel, 
                                                        long ulMode, 
                                                        char* pszFileName, 
                                                        char* pabFileData, 
                                                        long ulFileSize, 
                                                        PFN_PROGRESS_CALLBACK pfnCallback, 
                                                        PFN_RECV_PKT_CALLBACK pfnRecvPktCallback, 
                                                        void* pvUser);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelUpload")]
        private static extern long _xChannelUpload( CIFXHANDLE  hChannel, 
                                                    long ulMode, 
                                                    char* pszFileName, 
                                                    char* pabFileData, 
                                                    long* pulFileSize,
                                                    PFN_PROGRESS_CALLBACK pfnCallback, 
                                                    PFN_RECV_PKT_CALLBACK pfnRecvPktCallback, 
                                                    void* pvUser);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelGetMBXState")]
        private static extern long _xChannelGetMBXState(    CIFXHANDLE  hChannel, 
                                                            long* pulRecvPktCount, 
                                                            long* pulSendPktCount);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelPutPacket")]
        private static extern long _xChannelPutPacket(  CIFXHANDLE  hChannel, 
                                                        CIFX_PACKET*  ptSendPkt, 
                                                        long ulTimeout);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelGetPacket")]
        private static extern long _xChannelgetPacket(  CIFXHANDLE  hChannel, 
                                                        long ulSize, 
                                                        CIFX_PACKET* ptRecvPkt, 
                                                        long ulTimeout);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelGetSendPacket")]
        private static extern long _xChannelGetSendPacket(  CIFXHANDLE  hChannel, 
                                                            long ulSize, 
                                                            CIFX_PACKET* ptRecvPkt);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelConfigLock")]
        private static extern long _xChannelConfigLock( CIFXHANDLE  hChannel, 
                                                        long ulCmd, 
                                                        long* pulState, 
                                                        long ulTimeout);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelreset")]
        private static extern long _xChannelReset(  CIFXHANDLE  hChannel, 
                                                    long ulResetMode, 
                                                    long ulTimeout);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelInfo")]
        private static extern long _xChannelInfo(   CIFXHANDLE  hChannel, 
                                                    long ulSize, 
                                                    void* pvChannelInfo);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelWatchdog")]
        private static extern long _xChannelWatchdog(   CIFXHANDLE  hChannel, 
                                                        long ulCmd, 
                                                        long* pulTrigger);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelHostState")]
        private static extern long _xChannelHostState(  CIFXHANDLE  hChannel, 
                                                        long ulCmd, 
                                                        long* pulState, 
                                                        long ulTimeout);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelBusState")]
        private static extern long _xChannelBusState(   CIFXHANDLE  hChannel, 
                                                        long ulCmd, 
                                                        long* pulState, 
                                                        long ulTimeout);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelIOInfo")]
        private static extern long _xChannelIOInfo( CIFXHANDLE  hChannel, 
                                                    long ulCmd,        
                                                    long ulAreaNumber, 
                                                    long ulSize, 
                                                    void* pvData);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelIORead")]
        private static extern long _xChannelIORead( CIFXHANDLE  hChannel, 
                                                    long ulAreaNumber, 
                                                    long ulOffset,     
                                                    long ulDataLen, 
                                                    void* pvData, 
                                                    long ulTimeout);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelIOWrite")]
        private static extern long _xChannelIOWrite(    CIFXHANDLE  hChannel, 
                                                        long ulAreaNumber, 
                                                        long ulOffset,     
                                                        long ulDataLen, 
                                                        void* pvData, 
                                                        long ulTimeout);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelIOReadSendData")]
        private static extern long _xChannelIOReadSendData( CIFXHANDLE  hChannel, 
                                                            long ulAreaNumber, 
                                                            long ulOffset,     
                                                            long ulDataLen, 
                                                            void* pvData);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelControlBlock")]
        private static extern long _xChannelControlBlock(   CIFXHANDLE  hChannel, 
                                                            long ulCmd, 
                                                            long ulOffset, 
                                                            long ulDataLen, 
                                                            void* pvData);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelCommonStatusBlock")]
        private static extern long _xChannelCommonStatusBlock(  CIFXHANDLE  hChannel, 
                                                                long ulCmd, 
                                                                long ulOffset, 
                                                                long ulDataLen, 
                                                                void* pvData);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelExtendedStatusBlock")]
        private static extern long _xChannelExtendedStatusBlock(    CIFXHANDLE  hChannel, 
                                                                    long ulCmd, 
                                                                    long ulOffset, 
                                                                    long ulDataLen, 
                                                                    void* pvData);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelUserBlock")]
        private static extern long _xChannelUserBlock(  CIFXHANDLE  hChannel, 
                                                        long ulAreaNumber, 
                                                        long ulCmd, 
                                                        long ulOffset, 
                                                        long ulDataLen, 
                                                        void* pvData);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelPLCMemoryPtr")]
        private static extern long _xChannelPLCMemoryPtr(   CIFXHANDLE  hChannel, 
                                                            long ulCmd,        
                                                            void* pvMemoryInfo);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelPLCIsReadReady")]
        private static extern long _xChannelPLCIsReadReady( CIFXHANDLE  hChannel, 
                                                            long ulAreaNumber, 
                                                            long* pulReadState);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelPLCIsWriteReady")]
        private static extern long _xChannelPLCIsWriteReady(    CIFXHANDLE  hChannel, 
                                                                long ulAreaNumber, 
                                                                long* pulWriteState);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelPLCActivateWrite")]
        private static extern long _xChannelPLCActivateWrite(   CIFXHANDLE  hChannel, 
                                                                long ulAreaNumber);
        [DLLImport("cifx32dll.dll", EntryPoint = "xChannelPLCActivatedRead")]
        private static extern long _xChannelPLCActivateRead(    CIFXHANDLE  hChannel,
                                                                long ulAreaNumber);
    }
}