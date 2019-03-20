namespace Control_Pines_Arduino
{
    partial class FIRMATA
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FIRMATA));
            this.CONECTAR_DESCONECTAR = new System.Windows.Forms.Button();
            this.VELOCIDAD = new System.Windows.Forms.ComboBox();
            this.PUERTO = new System.Windows.Forms.ComboBox();
            this.BUSCA_PUERTO = new System.Windows.Forms.Button();
            this.ConexionSerial = new System.IO.Ports.SerialPort(this.components);
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.D14in = new System.Windows.Forms.Button();
            this.D14out = new System.Windows.Forms.Button();
            this.D15in = new System.Windows.Forms.Button();
            this.D15out = new System.Windows.Forms.Button();
            this.D16in = new System.Windows.Forms.Button();
            this.D16out = new System.Windows.Forms.Button();
            this.D17in = new System.Windows.Forms.Button();
            this.D17out = new System.Windows.Forms.Button();
            this.D18in = new System.Windows.Forms.Button();
            this.D18out = new System.Windows.Forms.Button();
            this.D19in = new System.Windows.Forms.Button();
            this.D19out = new System.Windows.Forms.Button();
            this.D20in = new System.Windows.Forms.Button();
            this.D20out = new System.Windows.Forms.Button();
            this.D21in = new System.Windows.Forms.Button();
            this.D21out = new System.Windows.Forms.Button();
            this.Temporizado = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.suma1 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.cbNodos = new System.Windows.Forms.ComboBox();
            this.nodos = new System.Windows.Forms.Label();
            this.Enviar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbconfirmacion = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.suma1)).BeginInit();
            this.SuspendLayout();
            // 
            // CONECTAR_DESCONECTAR
            // 
            this.CONECTAR_DESCONECTAR.BackColor = System.Drawing.Color.Lime;
            this.CONECTAR_DESCONECTAR.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CONECTAR_DESCONECTAR.Location = new System.Drawing.Point(13, 134);
            this.CONECTAR_DESCONECTAR.Name = "CONECTAR_DESCONECTAR";
            this.CONECTAR_DESCONECTAR.Size = new System.Drawing.Size(161, 32);
            this.CONECTAR_DESCONECTAR.TabIndex = 52;
            this.CONECTAR_DESCONECTAR.Text = "Conectar";
            this.CONECTAR_DESCONECTAR.UseVisualStyleBackColor = false;
            this.CONECTAR_DESCONECTAR.Click += new System.EventHandler(this.CONECTAR_DESCONECTAR_Click);
            // 
            // VELOCIDAD
            // 
            this.VELOCIDAD.Font = new System.Drawing.Font("Bookman Old Style", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VELOCIDAD.FormattingEnabled = true;
            this.VELOCIDAD.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "72800",
            "115200",
            "250000",
            "1000000"});
            this.VELOCIDAD.Location = new System.Drawing.Point(13, 99);
            this.VELOCIDAD.Margin = new System.Windows.Forms.Padding(4);
            this.VELOCIDAD.Name = "VELOCIDAD";
            this.VELOCIDAD.Size = new System.Drawing.Size(160, 23);
            this.VELOCIDAD.TabIndex = 51;
            this.VELOCIDAD.Text = "Vel. Transmisión";
            // 
            // PUERTO
            // 
            this.PUERTO.Font = new System.Drawing.Font("Bookman Old Style", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PUERTO.FormattingEnabled = true;
            this.PUERTO.Location = new System.Drawing.Point(13, 64);
            this.PUERTO.Margin = new System.Windows.Forms.Padding(4);
            this.PUERTO.Name = "PUERTO";
            this.PUERTO.Size = new System.Drawing.Size(160, 23);
            this.PUERTO.TabIndex = 50;
            this.PUERTO.Text = "Puertos COM";
            // 
            // BUSCA_PUERTO
            // 
            this.BUSCA_PUERTO.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BUSCA_PUERTO.Location = new System.Drawing.Point(13, 20);
            this.BUSCA_PUERTO.Margin = new System.Windows.Forms.Padding(4);
            this.BUSCA_PUERTO.Name = "BUSCA_PUERTO";
            this.BUSCA_PUERTO.Size = new System.Drawing.Size(161, 32);
            this.BUSCA_PUERTO.TabIndex = 49;
            this.BUSCA_PUERTO.Text = "Buscar Puertos";
            this.BUSCA_PUERTO.UseVisualStyleBackColor = true;
            this.BUSCA_PUERTO.Click += new System.EventHandler(this.BUSCA_PUERTO_Click);
            // 
            // ConexionSerial
            // 
            this.ConexionSerial.ReceivedBytesThreshold = 5;
            this.ConexionSerial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.ConexionSerial_DataReceived);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(726, 238);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(84, 16);
            this.label29.TabIndex = 153;
            this.label29.Text = "Entrada 15";
            this.label29.Visible = false;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.White;
            this.label30.Location = new System.Drawing.Point(726, 204);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(85, 16);
            this.label30.TabIndex = 152;
            this.label30.Text = "Entrada 14";
            this.label30.Visible = false;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.White;
            this.label35.Location = new System.Drawing.Point(725, 330);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(85, 16);
            this.label35.TabIndex = 156;
            this.label35.Text = "Entrada 18";
            this.label35.Visible = false;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.White;
            this.label36.Location = new System.Drawing.Point(725, 298);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(85, 16);
            this.label36.TabIndex = 155;
            this.label36.Text = "Entrada 17";
            this.label36.Visible = false;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.White;
            this.label37.Location = new System.Drawing.Point(725, 266);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(84, 16);
            this.label37.TabIndex = 154;
            this.label37.Text = "Entrada 16";
            this.label37.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(724, 425);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 16);
            this.label20.TabIndex = 159;
            this.label20.Text = "Entrada 21";
            this.label20.Visible = false;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.Color.White;
            this.label38.Location = new System.Drawing.Point(724, 393);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(85, 16);
            this.label38.TabIndex = 158;
            this.label38.Text = "Entrada 20";
            this.label38.Visible = false;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.White;
            this.label39.Location = new System.Drawing.Point(725, 362);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(85, 16);
            this.label39.TabIndex = 157;
            this.label39.Text = "Entrada 19";
            this.label39.Visible = false;
            // 
            // D14in
            // 
            this.D14in.Location = new System.Drawing.Point(817, 201);
            this.D14in.Name = "D14in";
            this.D14in.Size = new System.Drawing.Size(54, 23);
            this.D14in.TabIndex = 267;
            this.D14in.UseVisualStyleBackColor = true;
            this.D14in.Visible = false;
            // 
            // D14out
            // 
            this.D14out.Font = new System.Drawing.Font("Bookman Old Style", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D14out.Location = new System.Drawing.Point(407, 199);
            this.D14out.Name = "D14out";
            this.D14out.Size = new System.Drawing.Size(75, 23);
            this.D14out.TabIndex = 266;
            this.D14out.Text = "HIGH";
            this.D14out.UseVisualStyleBackColor = true;
            this.D14out.Click += new System.EventHandler(this.D14out_Click);
            // 
            // D15in
            // 
            this.D15in.Location = new System.Drawing.Point(817, 233);
            this.D15in.Name = "D15in";
            this.D15in.Size = new System.Drawing.Size(54, 23);
            this.D15in.TabIndex = 269;
            this.D15in.UseVisualStyleBackColor = true;
            this.D15in.Visible = false;
            // 
            // D15out
            // 
            this.D15out.Font = new System.Drawing.Font("Bookman Old Style", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D15out.Location = new System.Drawing.Point(407, 231);
            this.D15out.Name = "D15out";
            this.D15out.Size = new System.Drawing.Size(75, 23);
            this.D15out.TabIndex = 268;
            this.D15out.Text = "HIGH";
            this.D15out.UseVisualStyleBackColor = true;
            this.D15out.Click += new System.EventHandler(this.D15out_Click);
            // 
            // D16in
            // 
            this.D16in.Location = new System.Drawing.Point(816, 265);
            this.D16in.Name = "D16in";
            this.D16in.Size = new System.Drawing.Size(54, 23);
            this.D16in.TabIndex = 271;
            this.D16in.UseVisualStyleBackColor = true;
            this.D16in.Visible = false;
            // 
            // D16out
            // 
            this.D16out.Font = new System.Drawing.Font("Bookman Old Style", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D16out.Location = new System.Drawing.Point(406, 263);
            this.D16out.Name = "D16out";
            this.D16out.Size = new System.Drawing.Size(75, 23);
            this.D16out.TabIndex = 270;
            this.D16out.Text = "HIGH";
            this.D16out.UseVisualStyleBackColor = true;
            this.D16out.Click += new System.EventHandler(this.D16out_Click);
            // 
            // D17in
            // 
            this.D17in.Location = new System.Drawing.Point(816, 295);
            this.D17in.Name = "D17in";
            this.D17in.Size = new System.Drawing.Size(54, 23);
            this.D17in.TabIndex = 273;
            this.D17in.UseVisualStyleBackColor = true;
            this.D17in.Visible = false;
            // 
            // D17out
            // 
            this.D17out.Font = new System.Drawing.Font("Bookman Old Style", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D17out.Location = new System.Drawing.Point(406, 293);
            this.D17out.Name = "D17out";
            this.D17out.Size = new System.Drawing.Size(75, 23);
            this.D17out.TabIndex = 272;
            this.D17out.Text = "HIGH";
            this.D17out.UseVisualStyleBackColor = true;
            this.D17out.Click += new System.EventHandler(this.D17out_Click);
            // 
            // D18in
            // 
            this.D18in.Location = new System.Drawing.Point(816, 328);
            this.D18in.Name = "D18in";
            this.D18in.Size = new System.Drawing.Size(54, 23);
            this.D18in.TabIndex = 275;
            this.D18in.UseVisualStyleBackColor = true;
            this.D18in.Visible = false;
            // 
            // D18out
            // 
            this.D18out.Font = new System.Drawing.Font("Bookman Old Style", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D18out.Location = new System.Drawing.Point(406, 326);
            this.D18out.Name = "D18out";
            this.D18out.Size = new System.Drawing.Size(75, 23);
            this.D18out.TabIndex = 274;
            this.D18out.Text = "HIGH";
            this.D18out.UseVisualStyleBackColor = true;
            this.D18out.Click += new System.EventHandler(this.D18out_Click);
            // 
            // D19in
            // 
            this.D19in.Location = new System.Drawing.Point(816, 360);
            this.D19in.Name = "D19in";
            this.D19in.Size = new System.Drawing.Size(54, 23);
            this.D19in.TabIndex = 277;
            this.D19in.UseVisualStyleBackColor = true;
            this.D19in.Visible = false;
            // 
            // D19out
            // 
            this.D19out.Font = new System.Drawing.Font("Bookman Old Style", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D19out.Location = new System.Drawing.Point(406, 358);
            this.D19out.Name = "D19out";
            this.D19out.Size = new System.Drawing.Size(75, 23);
            this.D19out.TabIndex = 276;
            this.D19out.Text = "HIGH";
            this.D19out.UseVisualStyleBackColor = true;
            this.D19out.Click += new System.EventHandler(this.D19out_Click);
            // 
            // D20in
            // 
            this.D20in.Location = new System.Drawing.Point(816, 392);
            this.D20in.Name = "D20in";
            this.D20in.Size = new System.Drawing.Size(54, 23);
            this.D20in.TabIndex = 279;
            this.D20in.UseVisualStyleBackColor = true;
            this.D20in.Visible = false;
            // 
            // D20out
            // 
            this.D20out.Font = new System.Drawing.Font("Bookman Old Style", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D20out.Location = new System.Drawing.Point(406, 389);
            this.D20out.Name = "D20out";
            this.D20out.Size = new System.Drawing.Size(75, 23);
            this.D20out.TabIndex = 278;
            this.D20out.Text = "HIGH";
            this.D20out.UseVisualStyleBackColor = true;
            this.D20out.Click += new System.EventHandler(this.D20out_Click);
            // 
            // D21in
            // 
            this.D21in.Location = new System.Drawing.Point(816, 422);
            this.D21in.Name = "D21in";
            this.D21in.Size = new System.Drawing.Size(54, 23);
            this.D21in.TabIndex = 297;
            this.D21in.UseVisualStyleBackColor = true;
            this.D21in.Visible = false;
            // 
            // D21out
            // 
            this.D21out.Font = new System.Drawing.Font("Bookman Old Style", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D21out.Location = new System.Drawing.Point(406, 420);
            this.D21out.Name = "D21out";
            this.D21out.Size = new System.Drawing.Size(75, 23);
            this.D21out.TabIndex = 296;
            this.D21out.Text = "HIGH";
            this.D21out.UseVisualStyleBackColor = true;
            this.D21out.Click += new System.EventHandler(this.D21out_Click);
            // 
            // Temporizado
            // 
            this.Temporizado.Tick += new System.EventHandler(this.Temporizado_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(314, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 305;
            this.label1.Text = "Salida 8";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(314, 391);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 304;
            this.label2.Text = "Salida 7";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(315, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 303;
            this.label3.Text = "Salida 6";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(315, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 302;
            this.label4.Text = "Salida 5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(315, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 301;
            this.label5.Text = "Salida 4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(315, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 300;
            this.label6.Text = "Salida 3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(316, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 299;
            this.label7.Text = "Salida 2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(316, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 298;
            this.label8.Text = "Salida 1";
            // 
            // suma1
            // 
            this.suma1.Location = new System.Drawing.Point(315, 495);
            this.suma1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.suma1.Name = "suma1";
            this.suma1.Size = new System.Drawing.Size(151, 20);
            this.suma1.TabIndex = 306;
            this.suma1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(314, 469);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 13);
            this.label9.TabIndex = 307;
            this.label9.Text = "Sumar valor a Entradas";
            // 
            // cbNodos
            // 
            this.cbNodos.FormattingEnabled = true;
            this.cbNodos.Items.AddRange(new object[] {
            "Nodo 0",
            "Nodo 1",
            "Nodo 2",
            "Nodo 3",
            "Nodo 4",
            "Nodo 5"});
            this.cbNodos.Location = new System.Drawing.Point(529, 209);
            this.cbNodos.Name = "cbNodos";
            this.cbNodos.Size = new System.Drawing.Size(160, 21);
            this.cbNodos.TabIndex = 308;
            this.cbNodos.Text = "Nodos";
            this.cbNodos.SelectedIndexChanged += new System.EventHandler(this.cbNodos_SelectedIndexChanged);
            // 
            // nodos
            // 
            this.nodos.AutoSize = true;
            this.nodos.BackColor = System.Drawing.Color.Black;
            this.nodos.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nodos.Location = new System.Drawing.Point(526, 185);
            this.nodos.Name = "nodos";
            this.nodos.Size = new System.Drawing.Size(125, 16);
            this.nodos.TabIndex = 309;
            this.nodos.Text = "Selección de Nodos";
            // 
            // Enviar
            // 
            this.Enviar.Location = new System.Drawing.Point(529, 279);
            this.Enviar.Name = "Enviar";
            this.Enviar.Size = new System.Drawing.Size(160, 24);
            this.Enviar.TabIndex = 310;
            this.Enviar.Text = "Enviar";
            this.Enviar.UseVisualStyleBackColor = true;
            this.Enviar.Click += new System.EventHandler(this.Enviar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(317, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(184, 16);
            this.label10.TabIndex = 313;
            this.label10.Text = "Seleccion de nivel de salidas";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label11.Location = new System.Drawing.Point(455, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(156, 26);
            this.label11.TabIndex = 314;
            this.label11.Text = "Practica Prueba";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Location = new System.Drawing.Point(526, 344);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 16);
            this.label13.TabIndex = 316;
            this.label13.Text = "Datos: ";
            // 
            // lbconfirmacion
            // 
            this.lbconfirmacion.BackColor = System.Drawing.Color.White;
            this.lbconfirmacion.Location = new System.Drawing.Point(529, 375);
            this.lbconfirmacion.Name = "lbconfirmacion";
            this.lbconfirmacion.Size = new System.Drawing.Size(160, 23);
            this.lbconfirmacion.TabIndex = 317;
            this.lbconfirmacion.Text = "Confirmacion";
            this.lbconfirmacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.Location = new System.Drawing.Point(245, 71);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(579, 91);
            this.richTextBox1.TabIndex = 318;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // FIRMATA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(912, 525);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lbconfirmacion);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Enviar);
            this.Controls.Add(this.nodos);
            this.Controls.Add(this.cbNodos);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.suma1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.D21in);
            this.Controls.Add(this.D21out);
            this.Controls.Add(this.D20in);
            this.Controls.Add(this.D20out);
            this.Controls.Add(this.D19in);
            this.Controls.Add(this.D19out);
            this.Controls.Add(this.D18in);
            this.Controls.Add(this.D18out);
            this.Controls.Add(this.D17in);
            this.Controls.Add(this.D17out);
            this.Controls.Add(this.D16in);
            this.Controls.Add(this.D16out);
            this.Controls.Add(this.D15in);
            this.Controls.Add(this.D15out);
            this.Controls.Add(this.D14in);
            this.Controls.Add(this.D14out);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.CONECTAR_DESCONECTAR);
            this.Controls.Add(this.VELOCIDAD);
            this.Controls.Add(this.PUERTO);
            this.Controls.Add(this.BUSCA_PUERTO);
            this.Name = "FIRMATA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "s";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FIRMATA_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.suma1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CONECTAR_DESCONECTAR;
        private System.Windows.Forms.ComboBox VELOCIDAD;
        private System.Windows.Forms.ComboBox PUERTO;
        private System.Windows.Forms.Button BUSCA_PUERTO;
        private System.IO.Ports.SerialPort ConexionSerial;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Button D14in;
        private System.Windows.Forms.Button D14out;
        private System.Windows.Forms.Button D15in;
        private System.Windows.Forms.Button D15out;
        private System.Windows.Forms.Button D16in;
        private System.Windows.Forms.Button D16out;
        private System.Windows.Forms.Button D17in;
        private System.Windows.Forms.Button D17out;
        private System.Windows.Forms.Button D18in;
        private System.Windows.Forms.Button D18out;
        private System.Windows.Forms.Button D19in;
        private System.Windows.Forms.Button D19out;
        private System.Windows.Forms.Button D20in;
        private System.Windows.Forms.Button D20out;
        private System.Windows.Forms.Button D21in;
        private System.Windows.Forms.Button D21out;
        private System.Windows.Forms.Timer Temporizado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown suma1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbNodos;
        private System.Windows.Forms.Label nodos;
        private System.Windows.Forms.Button Enviar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbconfirmacion;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

