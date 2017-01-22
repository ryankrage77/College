using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPreALevelSkeleton {

    class Program {

        public const int NS = 4;
        public const int WE = 6;

        public struct CellReference {
            public int noOfCellsEast;
            public int noOfCellsSouth;
        }

        class Game {

            private Character player = new Character();
            private Grid cavern = new Grid();
            private Enemy monster = new Enemy();
            private Item flask = new Item();
            private Trap trap1 = new Trap();
            private Trap trap2 = new Trap();
            private Boolean trainingGame;

            public Game(Boolean isATrainingGame) {
                trainingGame = isATrainingGame;
                setUpGame();
                play();
            }

            public void play() {
                int count;
                Boolean eaten;
                Boolean flaskFound;
                char moveDirection;
                Boolean validMove;
                CellReference position;
                eaten = false;
                flaskFound = false;

                cavern.display(monster.getAwake());

                do {

                    do {

                        displayMoveOptions();
                        moveDirection = getMove();
                        validMove = checkValidMove(moveDirection);

                    } while (!validMove);

                    if (moveDirection != 'M') {

                        cavern.placeItem(player.getPosition(), ' ');

                        player.makeMove(moveDirection);

                        cavern.placeItem(player.getPosition(), '*');

                        cavern.display(monster.getAwake());

                        flaskFound = player.checkIfSameCell(flask.getPosition());
                        if (flaskFound) {
                            displayWonGameMessage();
                        }

                        eaten = monster.checkIfSameCell(player.getPosition());

                        // This selection structure checks to see if the player has
                        // triggered one of the traps in the cavern
                        if (!monster.getAwake() 
                            && !flaskFound 
                            && !eaten 
                            && (  ( player.checkIfSameCell(trap1.getPosition() ) && !trap1.getTriggered() ) 
                               || ( player.checkIfSameCell(trap2.getPosition() ) && !trap2.getTriggered() ) 
                               )
                            ) {
                            monster.changeSleepStatus();
                            displayTrapMessage();
                            cavern.display(monster.getAwake());
                        }

                        if (monster.getAwake() && !eaten && !flaskFound) {
                            count = 0;
                            do {
                                cavern.placeItem(monster.getPosition(), ' ');
                                position = monster.getPosition();
                                monster.makeMove(player.getPosition());
                                cavern.placeItem(monster.getPosition(), 'M');
                                if (monster.checkIfSameCell(flask.getPosition())) {
                                    flask.setPosition(position);
                                    cavern.placeItem(position, 'F');
                                }
                                eaten = monster.checkIfSameCell(player.getPosition());
                                Console.WriteLine();
                                Console.WriteLine("Press Enter key to continue");
                                Console.ReadLine();
                                cavern.display(monster.getAwake());
                                count = count + 1;
                            } while (count != 2 && !eaten);
                        }
                        if (eaten) {
                            displayLostGameMessage();
                        }
                    }
                } while (!eaten && !flaskFound && moveDirection != 'M');
            }

            public void displayMoveOptions() {
                Console.WriteLine();
                Console.WriteLine("Enter N to move NORTH");
                Console.WriteLine("Enter S to move SOUTH");
                Console.WriteLine("Enter E to move EAST");
                Console.WriteLine("Enter W to move WEST");
                Console.WriteLine("Enter M to return to the Main Menu");
                Console.WriteLine();
            }

            public char getMove() {
                char move;
                move = char.Parse(Console.ReadLine());
                Console.WriteLine();
                return move;
            }

            public void displayWonGameMessage() {
                Console.WriteLine("Well done! you have found the flask containing the Styxian potion.");
                Console.WriteLine("You ahve won the game of MONSTER!");
                Console.WriteLine();
            }

            public void displayTrapMessage() {
                Console.WriteLine("Oh no!  you have set off a trap.  Watch out, the monster is now awake!");
                Console.WriteLine();
            }

            public void displayLostGameMessage() {
                Console.WriteLine("ARGHHHHHH!  The monster has eaten you.  GAME OVER.");
                Console.WriteLine("maybe you will have better luck next time you play MONSTER!");
                Console.WriteLine();
            }

            public Boolean checkValidMove(char direction) {
                Boolean validMove;
                validMove = true;
                if (!(direction == 'N' || direction == 'S' || direction == 'W' || direction == 'E' || direction == 'M')) {
                    validMove = false;
                }
                return validMove;
            }

            public CellReference setPositionOfItem(char item) {
                CellReference position;
                do {
                    position = GetNewRandomPosition();
                } while (!cavern.isCellEmpty(position));
                cavern.placeItem(position, item);
                return position;
            }

            public void setUpGame() {

                CellReference position;
                
                cavern.reset();
                
                if (!trainingGame) {

                    position.noOfCellsEast = 0;
                    position.noOfCellsSouth = 0;
                    player.setPosition(position);
                    cavern.placeItem(position,'*');
                    trap1.setPosition(setPositionOfItem('T'));
                    trap2.setPosition(setPositionOfItem('T'));
                    monster.setPosition(setPositionOfItem('M'));
                    flask.setPosition(setPositionOfItem('F'));

                } else {

                    position.noOfCellsEast = 4;
                    position.noOfCellsSouth = 2;
                    player.setPosition(position);
                    cavern.placeItem(position, '*');
                    
                    position.noOfCellsEast = 6;
                    position.noOfCellsSouth = 2;
                    trap1.setPosition(position);
                    cavern.placeItem(position,'T');

                    position.noOfCellsEast = 4;
                    position.noOfCellsSouth = 3;
                    trap2.setPosition(position);
                    cavern.placeItem(position,'T');

                    position.noOfCellsEast = 4;
                    position.noOfCellsSouth = 0;
                    monster.setPosition(position);
                    cavern.placeItem(position,'M');

                    position.noOfCellsEast = 3;
                    position.noOfCellsSouth = 1;
                    flask.setPosition(position);
                    cavern.placeItem(position, 'F');

                }
            }

            public CellReference GetNewRandomPosition() {
                CellReference position;
                Random rnd = new Random();
                position.noOfCellsSouth = rnd.Next(0,NS+1);
                position.noOfCellsEast = rnd.Next(0,WE+1);
                return position;
            }

            class Grid {
                private char[,] cavernState = new char[NS + 1, WE + 1];

                public void reset() {
                    int count1;
                    int count2;
                    for (count1 = 0; count1 <= NS; count1++) {
                        for (count2 = 0; count2 <= WE; count2++) {
                            cavernState[count1,count2] = ' ';
                        }
                    }
                }

                public void display(Boolean monsterAwake) {
                    int count1;
                    int count2;
                    for (count1 = 0; count1 <= NS; count1++) {
                        Console.WriteLine(" ------------- ");
                        for (count2 = 0; count2 <= WE; count2++) { 
                            if (   cavernState[count1,count2] == ' ' 
                                || cavernState[count1,count2] == '*'
                                || cavernState[count1,count2] == 'M'
                                && monsterAwake) {
                                Console.Write("|" + cavernState[count1,count2]);
                            } e0lse {
                                Console.Write("| ");
                            }
                        }
                        Console.WriteLine("|");
                    }
                    Console.WriteLine(" ------------- ");
                    Console.WriteLine();
                }

                public void placeItem(CellReference position, char item) {
                    cavernState[position.noOfCellsSouth,position.noOfCellsEast] = item;
                }

                public Boolean isCellEmpty(CellReference position) {
                    if (cavernState[position.noOfCellsSouth,position.noOfCellsEast] == ' ')
                        return true;
                    else
                        return false;
                }
            }

            class Enemy : Item {

                private Boolean awake;

                public void makeMove(CellReference playerPosition) {

                    if (noOfCellsSouth < playerPosition.noOfCellsSouth) {
                        noOfCellsSouth = noOfCellsSouth + 1;
                    } else if (noOfCellsSouth > playerPosition.noOfCellsSouth) {
                        noOfCellsSouth = noOfCellsSouth - 1;
                    } else if (noOfCellsEast < playerPosition.noOfCellsEast) {
                        noOfCellsEast = noOfCellsEast + 1;
                    } else {
                        noOfCellsEast = noOfCellsEast -1;
                    }
                }

                public Boolean getAwake() {
                    return awake;
                }

                public void changeSleepStatus() {
                    if (!awake) {
                        awake = true;
                    } else {
                        awake = false;
                    }
                }

                public Enemy() {
                    awake = false;
                }

            }

            class Character : Item {

                public void makeMove(char direction) {

                    switch (direction) {

                        case 'N': 
                            noOfCellsSouth = noOfCellsSouth - 1;
                            break;

                        case 'S': 
                            noOfCellsSouth = noOfCellsSouth + 1;
                            break;

                        case 'W':
                            noOfCellsEast = noOfCellsEast - 1;
                            break;

                        case 'E':
                            noOfCellsEast = noOfCellsEast + 1;
                            break;
                    }
                }
            }

            class Trap : Item {

                private Boolean triggered;

                public Boolean getTriggered() {
                    return triggered;
                }

                public Trap() {
                    triggered = false;
                }

                public void toggleTrap() {
                    triggered = !triggered;
                }

            }

            class Item {

                protected int noOfCellsEast;
                protected int noOfCellsSouth;

                public CellReference getPosition() {
                    CellReference position;
                    position.noOfCellsEast = noOfCellsEast;
                    position.noOfCellsSouth = noOfCellsSouth;
                    return position;
                }

                public void setPosition(CellReference position) {
                    noOfCellsEast = position.noOfCellsEast;
                    noOfCellsSouth = position.noOfCellsSouth;
                }

                public Boolean checkIfSameCell(CellReference position) {
                    if (noOfCellsEast == position.noOfCellsEast
                        && noOfCellsSouth == position.noOfCellsSouth) {
                        return true;
                    } else {
                        return false;
                    }
                }

            }


        }

        static void Main(string[] args) {
            int choice = 0;
            while (choice != 9) {
                displayMenu();
                choice = getMainMenuChoice();
                switch (choice) {
                    case 1: 
                        Game newGame = new Game(false);
                        break;
                    case 2:
                        Game trainingGame = new Game(true);
                        break;
                }
            }
        }

        public static void displayMenu() {
            Console.WriteLine("MAIN MENU");
            Console.WriteLine();
            Console.WriteLine("1. Start new game");
            Console.WriteLine("2. Play training game");
            Console.WriteLine("9. Quit");
            Console.Write("Please enter your choice: ");
        }

        public static int getMainMenuChoice() {
            int choice;
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();
            return choice;
        }

    }
}
