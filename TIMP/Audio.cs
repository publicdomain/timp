#region © Copyright 2012, Luca Farias 
/* Copyright (c) 2012, Luca Farias 
L'autorizzazione è concessa, a titolo gratuito, a chiunque ottenga una copia
di questo software e dei file di documentazione associati , per utilizzare
il Software senza limitazioni, compresi, senza esclusione, i diritti
di usare, copiare, modificare, unire, pubblicare, distribuire, concedere in licenza e / o vendere
copie del Software, e di consentire alle persone a cui il software è
fornito le stesse, fatte salve le seguenti condizioni:

L'avviso di copyright e l'avviso di autorizzazione devono essere incluse in
tutte le copie o parti sostanziali del Software.

IL SOFTWARE VIENE FORNITO "COSÌ COM'È", SENZA GARANZIE DI ALCUN TIPO, ESPRESSE O
IMPLICITE, INCLUSE, MA NON SOLO, LE GARANZIE DI COMMERCIABILITÀ,
IDONEITÀ PER UN PARTICOLARE SCOPO E NON VIOLAZIONE. 
IN NESSUN CASO L'AUTORI O TITOLARI DEL COPYRIGHT POTRANNO ESSERE RITENUTI RESPONSABILI 
PER EVENTUALI RECLAMI, DANNI O ALTRE RESPONSABILITÀ, SIA IN UN'AZIONE DI CONTRATTO, 
TORTO O ALTRO, DERIVANTI DA ESSO, O IN CONNESSIONE CON IL SOFTWARE STESSO O L'USO 
 */
/* Copyright (c) 2012, Luca Farias 

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files , to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using NAudio.Wave;

namespace Silence
{
    public class Audio
    {
        #region -- Declare --
        public enum PlayBackState    // Stato della riproduzione
        {
             Stopped = 0, 
             Playing = 1,
             Paused = 2,
        }
        public event ErrorOccuredHandle Error;     // delegate per la gestione degli eventi di errore
        public delegate void ErrorOccuredHandle(string FunctionName, string ErrorMessage, string ErrorStach);

        public event PlayStopHandle PlaybackStop;           // delegate Evento stop esecuzione
        public delegate void PlayStopHandle(EventArgs e);

        private IWavePlayer _waveOutDevice;       // player NAudio 
        private WaveStream _mainOutputStream;     // Stream dei campioni audio NAudio
        private WaveChannel32 _volumeStream;      // Gestione proprietà del suono ( Volume, bilance ecc.)


        private bool _IsDispose = false;

      

        #endregion
        #region -- Proprietà --
        /// <summary>
        /// durata totale del brano 
        /// </summary>
        public TimeSpan  TotalDuration
        { 
            get
            {
                if (_mainOutputStream != null)
                     return _mainOutputStream.TotalTime;
                else
                    return new TimeSpan ();
            }
        }
        /// <summary>
        /// durata totale del brano in formato string MM:SS
        /// </summary>
        public string TotalTime 
        {
            get {
                if (_mainOutputStream != null ) 
                   return String.Format("{0:00}:{1:00}", (int)_mainOutputStream .TotalTime.TotalMinutes, _mainOutputStream .TotalTime.Seconds);
                else
                   return "00:00";
            }
        }
        #endregion
        #region  -- Controlli --
        /// <summary>
        /// Tempo di esecuzione attuale del brano
        /// </summary>
        public TimeSpan TimePosition 
        {
            get
            {
                if (_mainOutputStream == null) return  TimeSpan.Zero  ;

                return _mainOutputStream.CurrentTime;
            }
            set { _mainOutputStream.CurrentTime = value; }
            
        }
        /// <summary>
        /// Pausa
        /// </summary>
        public void Pause() 
        {
            if (_waveOutDevice == null) return;
            _waveOutDevice.Pause();
        }
        /// <summary>
        /// Play
        /// </summary>
        public void Play()
        {
           
            if (_waveOutDevice == null) return ;

            if (_waveOutDevice.PlaybackState == PlaybackState.Playing)
            {
                    return;
            }
       
            _waveOutDevice.Play();
             
        }  
        /// <summary>
        /// Stop
        /// </summary>
        public void Stop()
        {
            _waveOutDevice.Stop();
        }
        /// <summary>
        /// Volume di esecuzione 1.0 massimo 0.0 minimo
        /// </summary>
        public float Volume
        {
            get {return _volumeStream.Volume;  }
            set {
                if (_volumeStream != null)
                _volumeStream.Volume = value;}
            
        }
        /// <summary>
        /// Scelta canale audio L = -1.0 R = 1.0
        /// </summary>
        public float Pan
        {
            get {return _volumeStream.Pan;}
            set {
                if (_volumeStream != null)
                _volumeStream.Pan = value;
            }
        }
       /// <summary>
       /// Stato 
       /// </summary>
        public Audio.PlayBackState State
        {
            get 
            {
                if (_waveOutDevice != null)
                    return (PlayBackState )_waveOutDevice.PlaybackState;
                else
                    return Audio.PlayBackState.Stopped;  
            }
        }
        #endregion
        #region -- INTERNAL -- 
        public Audio ( string FileName )
        {
            if (!System.IO.File.Exists(FileName)) return;

            // Creazione della classe di interfaccia di riproduzione
            _waveOutDevice = new WaveOut();

            try
            {
                // creazione dello Stram di input dal file dato 
                _mainOutputStream = CreateInputStream(FileName);
                  
                if (_mainOutputStream == null)
                {
                    throw new InvalidOperationException("Unsupported file extension");
                }
                
            }
            catch (Exception createException)
            {
                if (Error != null)
                    Error("Audio - Play - CreateInputStream", createException.Message, createException.StackTrace);
                return;
            }

            try
            {
                // inizializzazione della risproduzione
                _waveOutDevice.Init(_mainOutputStream);
            }
            catch (Exception initException)
            {
                if (Error != null)
                    Error("Audio - Play - Init", initException.Message, initException.StackTrace);
                return;
            }
            
            // L'evento locale di stop dell'esecuzione viene aggangiato a quello della class NAudio
            _waveOutDevice.PlaybackStopped += new EventHandler<StoppedEventArgs>(_waveOutDevice_PlaybackStopped);
 
            return;

        }
        private void _waveOutDevice_PlaybackStopped (object sender, EventArgs e) 
        {
            // Se l'utilizzaztore della classe intende gestire l'evento questo viene generato
            if (PlaybackStop != null)
                PlaybackStop(e);
        }
        /// <summary>
        /// Dispose
        /// tutte le classi NAudio definite e inizializzate vengono opportunamente scaricate 
        /// </summary>
        public void Dispose() 
        {
            if (_waveOutDevice != null)
            {
                _waveOutDevice.Stop();
            }
            if (_mainOutputStream != null)
            {
                _volumeStream.Close();
                _volumeStream = null;
                _mainOutputStream.Close();
                _mainOutputStream = null;
            }
            if (_waveOutDevice != null)
            {
                _waveOutDevice.Dispose();
                _waveOutDevice = null;
            }
            GC.Collect();
            _IsDispose = true;
        }
        ~Audio()
        {
            if (!_IsDispose)
                this.Dispose();

        }
        /// <summary>
        /// Creazione dello Stream di input 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private WaveStream CreateInputStream(string fileName)
        {
             WaveStream Reader =  CreateReaderStream(fileName);
             
            if (Reader == null)
            {
                throw new InvalidOperationException("Unsupported extension");
            }
            // viene creata una classe WaveChannel32 agganciata allo stram di riproduzione per 
            // poter controllare l'esecuzione 
            _volumeStream =   new WaveChannel32(Reader);
            return _volumeStream;
        }
        /// <summary>
        /// Creazione dello Stream di lettura dle file in ingresso in base al tipo di file 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private WaveStream CreateReaderStream(string fileName)
        {
            WaveStream readerStream = null;
            if (fileName.EndsWith(".wav", StringComparison.OrdinalIgnoreCase))
            {
                readerStream = new WaveFileReader(fileName);
                if (readerStream.WaveFormat.Encoding != WaveFormatEncoding.Pcm && readerStream.WaveFormat.Encoding != WaveFormatEncoding.IeeeFloat)
                {
                    readerStream = WaveFormatConversionStream.CreatePcmStream(readerStream);
                    readerStream = new BlockAlignReductionStream(readerStream);
                }
            }
            else if (fileName.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase))
            {
                readerStream = new Mp3FileReader(fileName);
            }
            else if (fileName.EndsWith(".aiff"))
            {
                readerStream = new AiffFileReader(fileName);
            }
            return readerStream; 
        }


        #endregion
        
    }
    }

