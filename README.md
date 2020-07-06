# Jerry's Quest - проект по Визуелно програмирање 
Членови на тимот:

Ивана Ѓоршоска, бр. на иднекс: 185004

Тамара Малинова, бр. на индекс: 185061

## Опис на апликацијата
Проектот претставува игра во која играчот, играјќи со познатото глувче Џери, има за цел да собере што повеќе сиренца во период од 2 минути. Џери се движи во простор - лавиринт, којшто е случајно генериран. Притоа, при неговото движење, после секои 5 собрани сиренца, се генерира по една стапица во лавиринтот. Доколку играчот стапне на неа, се одземаат 45 секунди од преостанатото време. Сиренцата коишто ги собира му додаваат 5 секунди време во тајмерот. 

## Како се игра
На почетокот се појавува прозорец којшто претставува влез во играта. На прозорецот има 3 копчиња: Start, How To Play и Quit.

![Capture3](https://user-images.githubusercontent.com/63546054/86542802-4fac4900-bf19-11ea-80be-c513a540e29e.PNG)

Со клик на копчето Start се отвора прозорец за играње. 

![Capture](https://user-images.githubusercontent.com/63546054/86640628-c1000080-bfda-11ea-8523-c54ac364ff27.PNG)

Со клик на копчето How To Play, се отвора прозорец со инструкции за тоа како се игра. 

![Capture4](https://user-images.githubusercontent.com/63546054/86542827-897d4f80-bf19-11ea-88cc-b420dee5f0e8.PNG)

Со клик на копчето Quit, апликацијата се затвора.

По кликнување на копчето Start, се генерира лавиринт, се исцртуваат играчот и објектите за собирање и се поставува тајмерот на 2 минути. По изминување на времето, се појавува прозорец за Game Over каде што е прикажано колку поени освоил играчот, како и копчиња Play Again и Quit, со кои може да се започне нова игра или да се затвори апликацијата соодветно.

![Capture2](https://user-images.githubusercontent.com/63546054/86542837-a1ed6a00-bf19-11ea-82ad-9a8da5b18af5.PNG)

## Решение на проблемот

Cheese - класа која ги претставува сиренцата.

Jerry - класа која го претставува Џери и неговото движење.

MazeGenerator - класа која случајно го генерира лавиринтот.

MouseTrap - класа која ги претставува стапиците.

Home - форма за влез во играта.

HowToPlay - форма со инструкции за играта.

Game - форма во која е имплементирана играта.

GameOver - форма која се појавува по истекување на времето.

## Опис на класата Jerry.cs
Класата Jerry, како податочни елементи ги чува следните податоци:
енумерирачка листа за насоката на движење на играчот - DIRECTION, слика на играчот која се исцртува - player, X и Y координатата на играчот, drawX и drawY се вредностите вредностите на положбата на играчот во лавиринтот кои соодветно се сетираат во Game form, големина на интервал на тајмерот за движење на играчот и останати промени во лавиринтот (како додавања на сиренце/стапица и нивно тргање од лавиринтот) - Speed, насока на движење на играчот - direction, објект од калсата Random за генерирање на случајни броеви, целобројна променлива за чување на резултатот - score и бројот на земени стапици - removedTraps, како и листи од објекти во кои се чуваат сиренцата и стапиците кои се наоѓаат на лавиринтот - cheese и traps. 

Во конструкторот на класата се прави иницијализација на податоците. Вредностите x и y кои се праќаат како аргументи се пресметуваат по генерирање на лавиринтот и соодветно потоа се креира објект од оваа класа во формата на играта.
```
public Jerry(int x, int y)
        {
            X = x;
            Y = y;
            score = 0;
            removedTraps = 0;
            cheese = new List<Cheese>();
            traps = new List<MouseTrap>();
            Speed = 100;
            direction = DIRECTION.None;
            rand = new Random();
            player = Resources.jerry_running_left;
        }

```

Со методата Move се врши промена на насоката на играчот во зависност од притиснатото копче од тастатурата, како и додавање и отстанување на сиренца и стапици од лавиринтот. Најпрво се проверува вредноста на променливата direction и според неа се менуваат вредностите на координатите на играчот и доколку е потребно, се менува и сликата која се исцртува. 

Потоа се проверува дали при промената на положбата на играчот, тој дошол до поле на кое имало сиренце. Доколку е така, тој објект се отстанува од листата, променливата score се зголемува за 1, на играчот му се додава плус време на тајмерот и потоа се генерира ново сиренце на случајна позиција. 

Доколку играчот веќе собрал 5 сиренца, се генерира објект стапица на случајна позиција. Ова се повторува после секои 5 собрани сиренца. На крај, се проверува дали играчот дошол на поле на коешто имало стапица, со тоа што таа се отстранува од листата на стапици, се зголемува бројот на земени стапици и се намалува времето на тајмерот за 30 секунди. 
```
public void Move()
        {

            //move jerry
            if(direction == DIRECTION.Up)
            {
                Y--;
            }
            else if(direction == DIRECTION.Down)
            {
                Y++;
            }
            else if(direction == DIRECTION.Left)
            {
                X--;
                this.player = Resources.jerry_running_left;
            }
            else if(direction == DIRECTION.Right)
            {
                X++;
                this.player = Resources.jerry_running_right;
            }


            // remove collected cheese and add new
            for(int i=0; i<cheese.Count; i++)
            {
                if(cheese[i].X == this.X && cheese[i].Y == this.Y)
                {
                    score++;
                    cheese.Remove(cheese[i]);
                    Cheese newCh = newCheese(Game.WORLD_WIDTH, Game.WORLD_HEIGHT);
                    cheese.Add(newCh);
                }
            }
            

            // add new trap to the maze after 5 collected cheese icons
            if(score != 0 && score % 5 == 0)
            {
                if(traps.Count != (int)(score / 5) - removedTraps)
                {
                    MouseTrap trap = newMouseTrap(Game.WORLD_WIDTH, Game.WORLD_HEIGHT);
                    traps.Add(trap);
                }
            }

            // if trap is collected, remove from list
            for(int i=0; i<traps.Count; i++)
            {
                if(traps[i].X == this.X && traps[i].Y == this.Y)
                {
                    traps.Remove(traps[i]);
                    removedTraps++;
                }
            }
        }
```

Во методата newCheese се генерира нов објект - сиренце, при што се прават проверки за тоа дали позицијата е валидна, односно таа не треба да се совпаѓа со позицијата на играчот, не треба да совпаѓа со ѕид од лавиринтот и не треба да се совпаѓа со позиции на претходно генерирани објекти од класа Cheese или од класа Trap. Методата е имплементирана рекурзивно. 
```
public Cheese newCheese(int width, int height)
        {
            Cheese novo = new Cheese(rand.Next(0, width + 2), rand.Next(0, height + 2));
            if((novo.X == this.X && novo.Y == this.Y) || Game.maze[novo.Y, novo.X] == true)
            {
                novo = newCheese(width, height);
            }
            if (traps != null)
            {
                foreach (MouseTrap trap in traps)
                {
                    if (trap.X == novo.X && trap.Y == novo.Y)
                    {
                        novo = newCheese(width, height);
                        break;
                    }
                }
            }
            if (cheese != null)
            {
                foreach(Cheese ch in cheese)
                {
                    if(ch.X == novo.X && ch.Y == novo.Y)
                    {
                        novo = newCheese(width, height);
                        break;
                    }
                }
            }
            
            return novo;
        }
```

Методата newMouseTrap е за генерирање на нови стапици и проверките се иденитични како и во методата newCheese. 
```
public MouseTrap newMouseTrap(int width, int height)
        {
            MouseTrap novo = new MouseTrap(rand.Next(0, width + 2), rand.Next(0, height + 2));
            if((novo.X == this.X && novo.Y == this.Y) || Game.maze[novo.Y, novo.X] == true)
            {
                novo = newMouseTrap(width, height);
            }

            if (traps != null)
            {
                foreach (MouseTrap trap in traps)
                {
                    if (trap.X == novo.X && trap.Y == novo.Y)
                    {
                        novo = newMouseTrap(width, height);
                        break;
                    }
                }
            }

            if (cheese != null)
            {
                foreach (Cheese ch in cheese)
                {
                    if (ch.X == novo.X && ch.Y == novo.Y)
                    {
                        novo = newMouseTrap(width, height);
                        break;
                    }
                }
            }


            return novo;
        }
```

Методата drawJerry служи за исцртување на играчот - Џери, како и сите објекти од листите cheese и traps.
```
 public void drawJerry(Graphics g)
        {
            // draw jerry
            g.DrawImage(player, drawX, drawY, player.Width, player.Height);

            //draw cheese
            foreach(Cheese ch in cheese)
            {
                ch.drawCheese(g);
            }

            // draw traps
            foreach(MouseTrap trap in traps)
            {
                trap.drawTrap(g);
            }
        }
```
