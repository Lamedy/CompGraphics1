namespace Lab1_program
{
    public partial class MainForm : Form
    {
        private Graphics _graphics;
        private ObjectTransformation transformator = new ObjectTransformation();
        private MyObject myObject;
        private bool proection = true;
        private float changeProectionTick = 0;
        private float centerAxisOnScreenByX = 500;
        private float centerAxisOnScreenByY = 550;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this._graphics = CreateGraphics();
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            drawAxis();
            drawMyObject();
        }

        private void drawAxis()
        {
            float[,] coordinateAxes =
            {
                { 0, 0, 0, 1},
                { 500, 0, 0, 1},
                { 0, 500, 0, 1},
                { 0, 0, 500, 1},
                // Стрелка для оси X
                {490, 10, 0, 1},
                {490, -10, 0, 1},
                // Стрелка для оси Y
                {10, 490, 0, 1},
                {-10, 490, 0, 1},
                // Стрелка для оси Z
                {0, 10, 490, 1},
                {0, -10, 490, 1}
            };
            
            coordinateAxes = this.transformator.proectionObjectOnScreen(coordinateAxes, changeProectionTick);
            for (int i = 0; i < coordinateAxes.GetLength(0); i++)
            {
                coordinateAxes[i, 0] /= coordinateAxes[i, 3];
                coordinateAxes[i, 1] /= coordinateAxes[i, 3];
                coordinateAxes[i, 0] += this.centerAxisOnScreenByX;
                coordinateAxes[i, 1] += this.centerAxisOnScreenByY;
            }
            // Ось X
            this._graphics.DrawLine(new Pen(Color.Red, 3f), coordinateAxes[0, 0], coordinateAxes[0, 1], coordinateAxes[1, 0], coordinateAxes[1, 1]);
            this._graphics.DrawLine(new Pen(Color.Red, 3f), coordinateAxes[1, 0], coordinateAxes[1, 1], coordinateAxes[4, 0], coordinateAxes[4, 1]);
            this._graphics.DrawLine(new Pen(Color.Red, 3f), coordinateAxes[1, 0], coordinateAxes[1, 1], coordinateAxes[5, 0], coordinateAxes[5, 1]);
            // Ось Y
            this._graphics.DrawLine(new Pen(Color.Green, 3f), coordinateAxes[0, 0], coordinateAxes[0, 1], coordinateAxes[2, 0], coordinateAxes[2, 1]);
            this._graphics.DrawLine(new Pen(Color.Green, 3f), coordinateAxes[2, 0], coordinateAxes[2, 1], coordinateAxes[6, 0], coordinateAxes[6, 1]);
            this._graphics.DrawLine(new Pen(Color.Green, 3f), coordinateAxes[2, 0], coordinateAxes[2, 1], coordinateAxes[7, 0], coordinateAxes[7, 1]);
            // Ось Z
            this._graphics.DrawLine(new Pen(Color.Blue, 3f), coordinateAxes[0, 0], coordinateAxes[0, 1], coordinateAxes[3, 0], coordinateAxes[3, 1]);
            this._graphics.DrawLine(new Pen(Color.Blue, 3f), coordinateAxes[3, 0], coordinateAxes[3, 1], coordinateAxes[8, 0], coordinateAxes[8, 1]);
            this._graphics.DrawLine(new Pen(Color.Blue, 3f), coordinateAxes[3, 0], coordinateAxes[3, 1], coordinateAxes[9, 0], coordinateAxes[9, 1]);
        }

        private void drawMyObject()
        {
            if (this.myObject == null)
            {
                this.myObject = new MyObject();
                this.myObject.verticesList = this.transformator.dilatationObject(this.myObject.verticesList, 30f);
            }
            float[,] proectionObjectVertices = this.transformator.proectionObjectOnScreen(this.myObject.verticesList, changeProectionTick);


            for (int i = 0; i < this.myObject.edgesList.Count; i++)
            {
                this._graphics.DrawLine(
                    Pens.Black,
                    this.centerAxisOnScreenByX + proectionObjectVertices[this.myObject.edgesList[i][0], 0] / proectionObjectVertices[this.myObject.edgesList[i][0], 3],  // x1
                    this.centerAxisOnScreenByY + proectionObjectVertices[this.myObject.edgesList[i][0], 1] / proectionObjectVertices[this.myObject.edgesList[i][0], 3],  // y1
                    this.centerAxisOnScreenByX + proectionObjectVertices[this.myObject.edgesList[i][1], 0] / proectionObjectVertices[this.myObject.edgesList[i][1], 3],  // x2
                    this.centerAxisOnScreenByY + proectionObjectVertices[this.myObject.edgesList[i][1], 1] / proectionObjectVertices[this.myObject.edgesList[i][1], 3]   // y2
                );
            }
        }

        private void increaseButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                this.myObject.verticesList = this.transformator.dilatationObject(this.myObject.verticesList, 1.01f);
                this.Refresh();
            }
        }

        private void decreaseButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                this.myObject.verticesList = this.transformator.dilatationObject(this.myObject.verticesList, 0.99f);
                this.Refresh();
            }
        }

        private void positiveMoveObjByXButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                this.myObject.verticesList = this.transformator.moveObject(this.myObject.verticesList, x: 1f);
                this.Refresh();
            }
        }

        private void negativeMoveObjByXButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                this.myObject.verticesList = this.transformator.moveObject(this.myObject.verticesList, x: -1f);
                this.Refresh();
            }
        }

        private void positiveMoveObjByYButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                this.myObject.verticesList = this.transformator.moveObject(this.myObject.verticesList, y: 1f);
                this.Refresh();
            }
        }

        private void negativeMoveObjByYButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                this.myObject.verticesList = this.transformator.moveObject(this.myObject.verticesList, y: -1f);
                this.Refresh();
            }
        }

        private void positiveMoveObjByZButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                this.myObject.verticesList = this.transformator.moveObject(this.myObject.verticesList, z: 1f);
                this.Refresh();
            }
        }

        private void negativeMoveObjByZButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                this.myObject.verticesList = this.transformator.moveObject(this.myObject.verticesList, z: -1f);
                this.Refresh();
            }
        }

        private void rotateObjAroundXButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                this.myObject.verticesList = this.transformator.rotateObjectByAxisX(this.myObject.verticesList, -1f);
                this.Refresh();
            }
        }

        private void rotateObjAroundXButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                this.myObject.verticesList = this.transformator.rotateObjectByAxisX(this.myObject.verticesList, 1f);
                this.Refresh();
            }
        }

        private void rotateObjAroundYButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                this.myObject.verticesList = this.transformator.rotateObjectByAxisY(this.myObject.verticesList, -1f);
                this.Refresh();
            }
        }

        private void rotateObjAroundYButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                this.myObject.verticesList = this.transformator.rotateObjectByAxisY(this.myObject.verticesList, 1f);
                this.Refresh();
            }
        }

        private void rotateObjAroundZButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                this.myObject.verticesList = this.transformator.rotateObjectByAxisZ(this.myObject.verticesList, -1f);
                this.Refresh();
            }
        }

        private void rotateObjAroundZButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                this.myObject.verticesList = this.transformator.rotateObjectByAxisZ(this.myObject.verticesList, 1f);
                this.Refresh();
            }
        }

        private void onePointProection_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                if (this.proection)
                {
                    this.changeProectionTick += 0.05f;
                }
                else
                {
                    this.changeProectionTick -= 0.05f;
                }
                this.Refresh();
            }
            this.proection = !proection;
            this.Refresh();
        }
    }
}