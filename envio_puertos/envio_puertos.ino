//Se incluyen librerías.
#include <XBee.h>        
#include <Printers.h>  
#include "binary.h"
#include <Wire.h> 
#include <LiquidCrystal_I2C.h>

//Se definen las direcciones de los nodos a mandar (pueden ser tantos como sea necesario).
#define coordinador      0x0013A2004063D2BD
#define Router0          0x0013A2004063D1C0
#define Router1          0x0013A2004063D1E8
#define Router2          0x0013A2004063D260
#define Router3          0x0013A2004063D1C7

#define nodo0            0x0013A2004063D1FA
#define nodo1            0x0013A2004063D270
#define nodo2            0x0013A2004063D24D
#define nodo3            0x0013A20040993248
#define nodo4            0x0013A2004065D529
#define nodo5            0x0013A2004063D07C
//----------------------------------------------------------------------------------------

//Se redefinen los puertos seriales.
#define DebugSerial Serial    
#define XBeeSerial Serial1

XBeeWithCallbacks xbee;   //Se definen un objeto para las llamadas de Xbee.
LiquidCrystal_I2C lcd(0x3F, 20, 4); //adress 0x3f, 20 caracteres y 4 líneas

//Defina variables en esta sección.
uint8_t DatTX[2];//Dato a trasmitir (Puede ser un buffer más grande).  
uint8_t DatRX = 0;//Donde se guardan los datos recibidos (Puede ser un buffer más grande). 


int counter = 0; 
int counterold = 0; 
int aState;
int aLastState; 
int oldA = HIGH;
int oldB = HIGH;

uint64_t nodo;

//Se crean dos buffers para transmitir y recibir datos.
byte Datos[5]; //Buffer para recibir datos
byte Envio[5]; //Buffer para enviar datos


void setup() 
{
  //Configuración del puerto serial para debuggear. 
  DebugSerial.begin(9600);         //Velocidad del puerto.
  DebugSerial.println(F("Start")); //Mensaje de inicialización.
  //Configuración del puerto serial de comunicación.
  XBeeSerial.begin(9600);  //Velocidad del puerto.
  xbee.begin(XBeeSerial); //Definición del puerto por hardware para Xbee.
  // Configuración de las llamadas de funciones.
  xbee.onPacketError(printErrorCb, (uintptr_t)(Print*)&DebugSerial); //Imprime un mensaje de depuración al recibir un mensaje que indica un error. 
  xbee.onResponse(printErrorCb, (uintptr_t)(Print*)&DebugSerial); //Imprime un mensaje de depuración al producirse un error en la recepción.
  xbee.onZBRxResponse(processRxPacket); //llama a una función que se ejecuta al recibir datos. 

  lcd.init(); 
  lcd.backlight();
  lcd.setCursor (0,1);lcd.print("  INSTRUMENTACION ");
  lcd.setCursor (0,2);lcd.print("    ELECTRONICA");
  delay(1000);
  lcd.clear();
  lcd.setCursor (0,1);lcd.print("   BIENVENIDOS");
  delay(1000);
  lcd.clear();
  lcd.setCursor (0,0);lcd.print(" Practica Prueba ");
  lcd.setCursor (0,1);lcd.print(" Enviar: ");  
  lcd.setCursor (0,2);lcd.print(" -DATO: ");
  lcd.setCursor (0,3);lcd.print(" -NODO D: ");
  
  nodo=coordinador;//por defecto

  DDRC = 0b11111111;
  
  Envio[0] = 65; //
  Envio[1] = 67; // Bytes de sincronia, para el paquete que envia los datos 
  Envio[2] = 69; //
  Envio[3] = 0;  // Byte que contendrá los datos para el envio
}


//=================================================================================
//                              CIClO PRINCIPAL 
//=================================================================================
void loop() 
{
 //Revisa el puerto sorial para comprobar si hay un nuevo paquete de datos disponible
  xbee.loop(); 
  //getEncoderTurn();

 
 }

//=================================================================================
//                             SERIAL EVENT()
//=================================================================================
void serialEvent( ) {
    if(Serial.available() >= 6){
      for (int i = 0; i < 6 ; i++)
        {
           Datos[i] = Serial.read(); //Lee los datos recibidos y los guarda en el buffer Datos
        }
    }
      //En caso de que los BYTES de Sincronia sean iguales
      if (Datos[0] == 65 && Datos[1] == 67 && Datos[2] == 69) {            
            ES2();            //Funcion que controla los pines determinados como Entradas [14 - 21]
            salidas();        //Funcion que controla los pines determinados como Salidas  [35 - 42]            
            envio_datos();
            for (int h = 0; h < 5; h = h + 1) {
              Serial.write(Envio[h]);  // Envia los datos del buffer Buffer. El ciclo itera 4 veces (0-3) pues en cada iteración envia un byte de datos.
            }
      }
}

//==================================================================================================
//                            FUNCION DE RECEPCION DE DATOS 
//==================================================================================================

void processRxPacket(ZBRxResponse& rx, uintptr_t) {
Buffer BufRX(rx.getData(), rx.getDataLength());//Los datos recibidos los pasamos a un búfer de datos.

/*Los datos extraidos pueden ser de cualquier tipo y tamaño pero 
 tiene que ser del mismo tipo y tamaño desde donde se envían. */ 
DatRX = BufRX.remove<uint8_t>();//Extraemos el primer byte recibido del búfer. 

tone(22,500,50);//tono de 1000hz y 100ms de duracion
lcd.setCursor (13,3);lcd.print(DatRX);
       switch(DatRX)
       {
       case 0:
       lcd.setCursor (0,3);lcd.print(" Confirmacion: NO    ");
       Envio[4] = 0b00000000; 
       break;
      
       case 1:
       lcd.setCursor (0,3);lcd.print(" Confirmacion: SI    ");
       Envio[4] = 0b11111111; 

       default:
       break;
     }     
DebugSerial.println(F("DATO VALIDO RECIBIDO"));//Mensaje de depuración. 
printResponse(rx, DebugSerial);//Imprimimos lo que recibimos. 
}


//=================================================================================
//                        FUNCION DE MADADO DE DATOS 
//=================================================================================
void sendPacket() {
// prepara un frame del tipo Transmit Request modo API2.
ZBTxRequest txRequest;

//Le pasamos la dirección del nodo a trasmitir (se descomenta le sección del código del nodo al que se trasmite).
txRequest.setAddress64(nodo);//Trasmite al nodo indicado.


//Crea un búfer de 1 byte(el buffer puede ser de cualquier tamaño menor a 100 bytes).
AllocBuffer<2> packet;

packet.append(DatTX);//Introducimos en el búfer los datos a mandar.
txRequest.setPayload(packet.head, packet.len());//Lo introduce al frame.

//Manda los datos.
xbee.send(txRequest);
} 


//=================================================================================
//                       CONTROL DE ENTRADAS
//=================================================================================
void ES2() {
    /*Cada bit del byte 3 representa un pin de Entrada. Se lee el estado del pin determinado como entrada,
    si está HIGH coloca un 1 y si la lectura arroja un LOW se coloca un cero. Para ello utiliza operaciones lógicas AND y OR */

    //--------------PIN 14, Entrada 1 LSB
    //-----------------------------------
    pinMode(14,INPUT);           
    if (digitalRead(14) == HIGH) {
        Envio[3] = Envio[3] | 0b00000001;
     }
    else {
        Envio[3] = Envio[3] & 0b11111110;
     }
    //--------------PIN 15, Entrada 2
    //------------------------------------
    pinMode(15,INPUT);
    if (digitalRead(15) == HIGH) {
        Envio[3] = Envio[3] | 0b00000010;
    }
    else {
        Envio[3] = Envio[3] & 0b11111101;
    }
    //--------------PIN 16, Entrada 3.
    //-------------------------------------
    pinMode(16,INPUT); 
    if (digitalRead(16) == HIGH) {
        Envio[3] = Envio[3] | 0b00000100;
    }
    else {
        Envio[3] = Envio[3] & 0b11111011;
    }
    //--------------PIN 17, Entrada 4.
    //-------------------------------------
    pinMode(17,INPUT);
    if (digitalRead(17) == HIGH) {
        Envio[3] = Envio[3] | 0b00001000;
    }
    else {
        Envio[3] = Envio[3] & 0b11110111;
    }
    //--------------PIN 18, Entrada 5.
    //-------------------------------------
    pinMode(18,INPUT);
    if (digitalRead(18) == HIGH) {
        Envio[3] = Envio[3] | 0b00010000;
    }
    else {
        Envio[3] = Envio[3] & 0b11101111;
    }
    //--------------PIN 19, Entrada 6.
    //-------------------------------------
    pinMode(19,INPUT);
    if (digitalRead(19) == HIGH) {
        Envio[3] = Envio[3] | 0b00100000;
    }
    else {
        Envio[3] = Envio[3] & 0b11011111;
    }
    //--------------PIN 20, Entrada 7.
    //-------------------------------------
     pinMode(20,INPUT);
     if (digitalRead(20) == HIGH) {
         Envio[3] = Envio[3] | 0b01000000;
     }
     else {
         Envio[3] = Envio[3] & 0b10111111;
     }
    //--------------PIN 19, Entrada 6.
    //-------------------------------------
    pinMode(21,INPUT);
    if (digitalRead(21) == HIGH) {
       Envio[3] = Envio[3] | 0b10000000;
    }
    else {
       Envio[3] = Envio[3] & 0b01111111;
    }          
}

//=================================================================================
//                       CONTROL DE SALIDAS 
//=================================================================================
void salidas(){
  //Esta función permite poner los pines designados como Salida en Alto o bajo dependiendo de las indicaciones recibidas via puerto serial desde la aplicación en C#
   lcd.setCursor (9,2); lcd.print(Datos[3]);  
   PORTC = Datos[3];
  }

//=================================================================================
//                        ENVIO DE DATOS XBEE 
//=================================================================================
void envio_datos(){
    counter = Datos[4];
  
    if (counter !=  counterold)
   {
    counterold = counter;
    //cambia el menu de la pantalla
    switch (counter)
    {
       case 0:
       lcd.setCursor (0,3);lcd.print(" -NODO: Coordinador  ");
       nodo=coordinador;
       break;

       case 2:
       lcd.setCursor (0,3);lcd.print(" -NODO: Router0      ");
       nodo=Router0;
       break;

       case 4:
       lcd.setCursor (0,3);lcd.print(" -NODO: Router1      ");
       nodo=Router1;
       break;

       case 6:
       lcd.setCursor (0,3);lcd.print(" -NODO: Router2      ");
       nodo=Router2;
       break;

       case 8:
       lcd.setCursor (0,3);lcd.print(" -NODO: Router3      ");
       nodo=Router3;
       break;

       case 10:
       lcd.setCursor (0,3);lcd.print(" NODO: Nodo0        ");
       nodo=nodo0;
       break;
       
       case 12:
       lcd.setCursor (0,3);lcd.print(" -NODO: Nodo1        ");
       nodo=nodo1;
       break;

       case 14:
       lcd.setCursor (0,3);lcd.print(" -NODO: Nodo2        ");
       nodo=nodo2;
       break;

       case 16:
       lcd.setCursor (0,3);lcd.print(" -NODO: Nodo3        ");
       nodo=nodo3;
       break;

       case 18:
       lcd.setCursor (0,3);lcd.print(" -NODO: Nodo4        ");
       nodo=nodo4;
       break;
       
       case 20:
       lcd.setCursor (0,3);lcd.print(" -NODO: Nodo5        ");
       nodo=nodo5;
       break;
       
       default:
       break;
    }
   }

  if(Datos[5] == 255)
   {
    DatTX[0]=0x01; //identificacion del nodo programado.
    DatTX[1]=Datos[3];
    sendPacket();//Llama a la función de trasmisión.
   }  
 }



