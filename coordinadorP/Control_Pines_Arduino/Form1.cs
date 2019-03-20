using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Control_Pines_Arduino
{
    public partial class FIRMATA : Form
    {
        public FIRMATA()
        {
            InitializeComponent();
        }


        /*--------------FRAME: Define los bytes para envio y recepción de datos----------------- */
        /*Se forma el paquete que sera enviado a arduino por comunicación serial para modificar
         * los parametros de los pines de entrada y salida. Así como la definición de los bytes necesarios
         * para la recepción de datos*/
        private byte[] paquete = new byte[6];                   //Se declara el paquete de bytes que sera enviado a arduino     
        private int sincronia1 = 65;                            //Byte 0  Estos tres bytes [0,1,2] sirven para identificar el 
        private int sincronia2 = 67;                            //Byte 1  inicio del paquete de datos. Corresponden a una letra
        private int sincronia3 = 69;                            //Byte 2  A, C, E en hexadecimal.
        private int nivel_salidas2 = 0;                         //Byte que contiene los datos utilizados para cambiar el estado (LOW-HIGH) de los pines utilizados
       // int sumador = 0;                                //Byte que almacena el resultado de operacion. Indicará cuales pines de salida colocar en HIGH    
        private int envio_coordinador= 7;
        private int habilitar_envio = 0; 


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /*------------BUSCAR PUERTO: Revisa los puertos COM disponibles ----------------- */
        //Obtiene los puertos disponibles y permite al usuario seleccionar puerto y velocidad de transmisión
        private void BUSCA_PUERTO_Click(object sender, EventArgs e)
        {   
            string[] puertosDisponibles = System.IO.Ports.SerialPort.GetPortNames(); //Obtiene una lista de los puertos  seriales disponibles
            PUERTO.Items.Clear();   //Limpia el combobox (Efecto de UX)
            foreach (string puertos in puertosDisponibles)
            {
                PUERTO.Items.Add(puertos);  //Utiliza un ciclo para añadir los puertos encontrados al combo box
            }
            if (PUERTO.Items.Count > 0)
            {   //Si existen puertos disponibles         
                MessageBox.Show("Seleccione un puerto y una velocidad de transmisión"); //despliega el mensaje     
                CONECTAR_DESCONECTAR.Enabled = true; // Habilita el boton que se encarga de establecer conexión con el puerto seleccionado. 
            }
            else
            {
                //Si no existen puertos
                MessageBox.Show("No se detectan puertos"); //Despliega el mensaje
                PUERTO.Items.Clear(); //Limpia el Combobox
                PUERTO.Text = "Puertos COM"; //Restablece el texto del combo box. 
                CONECTAR_DESCONECTAR.Enabled = false; // Deshabilita el boton que se encarga de establecer conexión con el puerto seleccionado. 
            }
        }

        /*------------CONECTAR:  establece  o no una conexión----------------- */
        /*Se conecta y desconecta. Abre y cierra el puerto, visualmente los botones
         * cambian de apariencia */
        private void CONECTAR_DESCONECTAR_Click(object sender, EventArgs e)
        {
            try
            {
                // Para conectar. Evento que ocurre al presionar el boton para establecer conexion
                if (CONECTAR_DESCONECTAR.Text == "Conectar")
                { // Declaración de los parametros necerarios para la transmisión de datos
                    ConexionSerial.PortName = PUERTO.Text;  //Define el puerto. Adquiere el valor seleccionado en el combobox "PUERTO"
                    ConexionSerial.BaudRate = Int32.Parse(VELOCIDAD.Text); //Define la velocidad de transmisión. Adquiere el valor seleccionado en el combobox "VELOCIDAD"
                    ConexionSerial.Parity = System.IO.Ports.Parity.None; //Define la característica de  Pariedad = NONE
                    ConexionSerial.StopBits = System.IO.Ports.StopBits.One; //Define la característica de Bit de parada = ONE
                    ConexionSerial.DataBits = 8; //Obtiene o establece la longitud estándar de los bits de datos por byte.
                    ConexionSerial.Handshake = System.IO.Ports.Handshake.None; // Handshake = none
                    ConexionSerial.Open();  //Se abre el puerto
                    Temporizado.Enabled = true; //Se habilita el timer [cada cuánto se hará un envio de paquete] Programado desde el entorno gráfico a 500 ms.

                    try
                    {
                        //Cambia la interfaz para desconectar
                        CONECTAR_DESCONECTAR.Text = "Desconectar"; //Cambia el texto impreso en el botón de "Conexión/desconexión"
                        CONECTAR_DESCONECTAR.BackColor = Color.Red; //Cambia el color del botón
                        BUSCA_PUERTO.Enabled = false;  //Inhabilita el boton de busqueda de puertos. 
                    }

                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message.ToString()); //En caso de no poder conectar [ej. Puerto ocupado]
                    }
                }
                //Entra al dar click y que el boton tenga como texto "Desconectar"
                else if (CONECTAR_DESCONECTAR.Text == "Desconectar")
                {
                    Temporizado.Enabled = false;    //Deshabilita el timer de transmisión de datos.
                    ConexionSerial.Close();         //Cierra el puerto
                    CONECTAR_DESCONECTAR.Text = "Conectar"; //Cambia el texto del botón 
                    CONECTAR_DESCONECTAR.BackColor = Color.Lime; //Cambia el color del botón 
                    BUSCA_PUERTO.Enabled = true; //Habilita de nuevo el botón de busqueda de puertos.
                    PUERTO.Text = "Puertos COM"; //Regresa el combobox de puertos a su estado inicial
                    VELOCIDAD.Text = "Vel. Transmisión"; //Regresa el combobox de Velocidad a su estado inicial
                }
            }

            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString()); //En caso de no haber seleccionado las propiedades de transmisión (Puerto y velocidad)
            }
        }

        /*---------------------- CONTROL DE SALIDAS----------------------------------*/
        /*Esta sección permite el cambio de estado de los pines de salida declarados en arduino 
         en función del evento de un boton, al cambiar el estado y texto del botón se modifica el
         contenido del byte de datos que indica si el pin debe estar en HIGH o LOW. 
        Esta compuesta por una serie de botones[8] que definen el estado de los pines
         definidos como salida. Utiliza operaciones lógicas para comprobar la instrucción recibida; 
         And = coloca CEROS
         OR = Coloca UNOS
         Ejemplo:
            rb_Entradas = rb_Entradas | 0b00000001; <- Esta linea al hacer or con el byte el resultado
            unicamente será 1 para el primer bit cuando la Entrada ya tenga un 1 en el primer bit en caso contrario 
            colocará un cero en el bit 1 apagandolo
            | 0b10010001     & 0b10010001
              0b00000001       0b11111110
             ____________    ____________
              0b10010001       0b10010000 
                   a               b
                   
             a= enciende el primer bit deseado y respeta el estado de los demás bits
             b= mantiene encendidos los demás bits y apaga el bit indicado, en este caso el menos significativo*/
        //Boton de la Salida 1 bit [LSB 0b00000001]
        private void D14out_Click(object sender, EventArgs e)
        {
            if (D14out.Text == "HIGH")
            {
                
                nivel_salidas2 = nivel_salidas2 | 0b00000001;
                D14out.Text = "LOW";
            }
            else if (D14out.Text == "LOW")
            {
                nivel_salidas2 = nivel_salidas2 & 0b11111110;
                D14out.Text = "HIGH";
            }
        }
        //Boton de la Salida 2 bit [0b00000010]
        private void D15out_Click(object sender, EventArgs e)
        {
            if (D15out.Text == "HIGH")
            {
                nivel_salidas2 = nivel_salidas2 | 0b00000010;
                D15out.Text = "LOW";
            }
            else if (D15out.Text == "LOW")
            {
                nivel_salidas2 = nivel_salidas2 & 0b11111101;
                D15out.Text = "HIGH";
            }
        }
        //Boton de la Salida 3 bit [0b00000100]
        private void D16out_Click(object sender, EventArgs e)
        {
            if (D16out.Text == "HIGH")
            {
                nivel_salidas2 = nivel_salidas2 | 0b00000100;
                D16out.Text = "LOW";
            }
            else if (D16out.Text == "LOW")
            {
                nivel_salidas2 = nivel_salidas2 & 0b11111011;
                D16out.Text = "HIGH";
            }
        }
        //Boton de la Salida 4 bit [0b00001000]
        private void D17out_Click(object sender, EventArgs e)
        {
            if (D17out.Text == "HIGH")
            {
                nivel_salidas2 = nivel_salidas2 | 0b00001000;
                D17out.Text = "LOW";
            }
            else if (D17out.Text == "LOW")
            {
                nivel_salidas2 = nivel_salidas2 & 0b11110111;
                D17out.Text = "HIGH";
            }
        }
        //Boton de la Salida 5 bit [0b00010000]
        private void D18out_Click(object sender, EventArgs e)
        {
            if (D18out.Text == "HIGH")
            {
                nivel_salidas2 = nivel_salidas2 | 0b00010000;
                D18out.Text = "LOW";
            }
            else if (D18out.Text == "LOW")
            {
                nivel_salidas2 = nivel_salidas2 & 0b11101111;
                D18out.Text = "HIGH";
            }
        }
        //Boton de la Salida 6 bit [0b00100000]
        private void D19out_Click(object sender, EventArgs e)
        {
            if (D19out.Text == "HIGH")
            {
                nivel_salidas2 = nivel_salidas2 | 0b00100000;
                D19out.Text = "LOW";
            }
            else if (D19out.Text == "LOW")
            {
                nivel_salidas2 = nivel_salidas2 & 0b11011111;
                D19out.Text = "HIGH";
            }
        }
        //Boton de la Salida 7 bit [0b01000000]
        private void D20out_Click(object sender, EventArgs e)
        {
            if (D20out.Text == "HIGH")
            {
                nivel_salidas2 = nivel_salidas2 | 0b01000000;
                D20out.Text = "LOW";
            }
            else if (D20out.Text == "LOW")
            {
                nivel_salidas2 = nivel_salidas2 & 0b10111111;
                D20out.Text = "HIGH";
            }
        }
        //Boton de la Salida 8 bit [MSB 0b10000010]
        private void D21out_Click(object sender, EventArgs e)
        {
            if (D21out.Text == "HIGH")
            {
                nivel_salidas2 = nivel_salidas2 | 0b10000000;
                D21out.Text = "LOW";
            }
            else if (D21out.Text == "LOW")
            {
                nivel_salidas2 = nivel_salidas2 & 0b01111111;
                D21out.Text = "HIGH";
            }
        }
        /*Fin de seccion--------------------------------------------------------*/

       /*--------------------------CIERRE DEL FORM------------------------------*/
        private void FIRMATA_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConexionSerial.Close(); // Al cerrar el form se asegura de cerrar el puerto serial 
        }

        /*--------------------------RECEPCION DE DATOS------------------------------*/
        /*Interrupcion o evento de recepcion que nos dice cuando recibe un paquete por parte
         de Arduino.  */
        int index = 0;
        byte[] datos = new byte[100];
               
        private void ConexionSerial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            //Lee una cadena de BYTES
            ConexionSerial.Read(datos, 0, 5);
            
            while (datos[index] != 65)
            { //Este ciclo busca el bit se sincronia para evitar la lectura de bytes incompletos
                index = index + 1;  // utiliza un index para poder ubicarse a lo largo del byte
                datos[4 + index] = (byte)ConexionSerial.ReadByte(); 
            }
            if (datos[index] == 65 && datos[index + 1] == 67 && datos[index + 2] == 69)
            {     //Cuando el se encuentra con la lectura del byte correcto verifica uno a uno el estado de los bits 
                if (datos[index + 4] == 0b11111111)
                {
                    lbconfirmacion.BackColor = Color.Gray;
                    lbconfirmacion.Text = "Correcto";

                }

                if (datos[index + 4] == 0b00000000)
                {
                    lbconfirmacion.BackColor = Color.Red;
                    lbconfirmacion.Text = "Incorrecto";
                }

                //Bit LSB Entrada 1 
                if ((datos[index + 3] & 0b00000001) == 0b00000001)
                    {
                        D14in.BackColor = Color.Red;
                        D14in.ForeColor = Color.White;
                        D14in.Text = "HIGH";
                    }
                    else
                    {
                        D14in.BackColor = Color.Black;
                        D14in.ForeColor = Color.White;
                        D14in.Text = "LOW";
                    }
                
                //Bit Entrada 2
                    if ((datos[index + 3] & 0b00000010) == 0b00000010)
                    {
                        D15in.BackColor = Color.Red;
                        D15in.ForeColor = Color.White;
                        D15in.Text = "HIGH";
                    }
                    else
                    {
                        D15in.BackColor = Color.Black;
                        D15in.ForeColor = Color.White;
                        D15in.Text = "LOW";
                    }
                
                //Bit Entrada 3
                    if ((datos[index + 3] & 0b00000100) == 0b00000100)
                    {
                        D16in.BackColor = Color.Red;
                        D16in.ForeColor = Color.White;
                        D16in.Text = "HIGH";
                    }
                    else
                    {
                        D16in.BackColor = Color.Black;
                        D16in.ForeColor = Color.White;
                        D16in.Text = "LOW";
                    }
                
               //Bit Entrada 4 
                    if ((datos[index + 3] & 0b00001000) == 0b00001000)
                    {
                        D17in.BackColor = Color.Red;
                        D17in.ForeColor = Color.White;
                        D17in.Text = "HIGH";
                    }
                    else
                    {
                        D17in.BackColor = Color.Black;
                        D17in.ForeColor = Color.White;
                        D17in.Text = "LOW";
                    }
                
                //Bit Entrada 5 
                    if ((datos[index + 3] & 0b00010000) == 0b00010000)
                    {
                        D18in.BackColor = Color.Red;
                        D18in.ForeColor = Color.White;
                        D18in.Text = "HIGH";
                    }
                    else
                    {
                        D18in.BackColor = Color.Black;
                        D18in.ForeColor = Color.White;
                        D18in.Text = "LOW";
                    }
                
                //Bit Entrada 6 
                    if ((datos[index + 3] & 0b00100000) == 0b00100000)
                    {
                        D19in.BackColor = Color.Red;
                        D19in.ForeColor = Color.White;
                        D19in.Text = "HIGH";
                    }
                    else
                    {
                        D19in.BackColor = Color.Black;
                        D19in.ForeColor = Color.White;
                        D19in.Text = "LOW";
                    }
                
                //Bit Entrada 7 
                    if ((datos[index + 3] & 0b01000000) == 0b01000000)
                    {
                        D20in.BackColor = Color.Red;
                        D20in.ForeColor = Color.White;
                        D20in.Text = "HIGH";
                    }
                    else
                    {
                        D20in.BackColor = Color.Black;
                        D20in.ForeColor = Color.White;
                        D20in.Text = "LOW";
                    }
                
               //Bit MSB Entrada 8 
                    if ((datos[index + 3] & 0b10000000) == 0b10000000)
                    {
                        D21in.BackColor = Color.Red;
                        D21in.ForeColor = Color.White;
                        D21in.Text = "HIGH";
                    }
                    else
                    {
                        D21in.BackColor = Color.Black;
                        D21in.ForeColor = Color.White;
                        D21in.Text = "LOW";
                    }

                


            }
            index = 0;

        }
        /*Fin de sección-------------------------------------------------------------*/


        /*------------------ENVIO DE PAQUETES DE DATOS POR PUERTO SERIAL--------------*/
        /*Este evento está asociado al timer cuyo intervalo es de 500ms. Cada 500ms hará 
         la comprobación del paquete e implementará el método Serial.Write para enviar el
         paquete de bytes. Cada que se modifica la interfaz se actualiza el paquete de bytes*/
        
        private void Temporizado_Tick(object sender, EventArgs e)
        {                                
            //Un vez formado el paquete, este se envia a Arduino
            paquete[0] = (byte)sincronia1; // Estos bytes sirven para indicar el inicio de la trama
            paquete[1] = (byte)sincronia2; // Estos bytes sirven para indicar el inicio de la trama
            paquete[2] = (byte)sincronia3; // Estos bytes sirven para indicar el inicio de la trama
            paquete[3] = (byte)nivel_salidas2; // Byte que contiene la información que marca las instrucciones al arduino
            paquete[4] = (byte)envio_coordinador;
            paquete[5] = (byte)habilitar_envio;

            //Metodo para enviar un paquete de BYTES
            ConexionSerial.Write(paquete, 0, paquete.Length);
            habilitar_envio = 0;

        }
        /*Fin de seccion ---------------------------------------------------------------*/

            
        /*-------------------------EVENTO DE OPERACION: Suma.---------------------------*/
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int sumador = Convert.ToInt32(suma1.Value);  //Toma el valor del contenedor (suma1) y lo convierte a un dato entero
            nivel_salidas2 = sumador + datos[index + 3]; //Suma el valor del contenedor al valor dado por las entradas del Arduino y el 
                                                         //resultado lo asigna al byte que controla las salidas del arduino
        }

                    
        private void Enviar_Click(object sender, EventArgs e)
        {
            habilitar_envio = 255;

        }

        private void cbNodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbNodos.SelectedItem.ToString().Trim())
            {
               
                case "Nodo 0":
                    envio_coordinador = 10;
                    break;

                case "Nodo 1":
                    envio_coordinador = 12;
                    break;

                case "Nodo 2":
                    envio_coordinador = 14;
                    break;

                case "Nodo 3":
                    envio_coordinador = 16;
                    break;

                case "Nodo 4":
                    envio_coordinador = 18;
                    break;

                case "Nodo 5":
                    envio_coordinador = 20;
                    break;

                default:

                    break;
            }
            
            
        }









        /*Fin de la seccion-------------------------------------------------------------*/


    }
}
