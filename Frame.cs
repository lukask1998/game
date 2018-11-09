public class Frame extends JFrame implements MenuListener, ActionListener, KeyListener {

    private static JFrame frame;
    private static JPanel panel;
    private static JMenuBar menuBar;
    private static JMenu options;
    private static JMenuItem newGame;

    //other variables
    private boolean var = true;
    private int move = 0;
    private final int BUTTON_NUMBER = 9;

    //win indicators
    private int[][] winIndices = {{0,1,2}, {3,4,5}, {6,7,8}, {0,3,6}, {1,4,7}, {2,5,8}, {0,4,8}, {2,4,6}};

    //buttons list
    List<JButton> buttonList = new ArrayList<>();

    public Frame() {

        //create frame
        frame = new JFrame();

        //create menu bar
        menuBar = new JMenuBar();

        //create panel
        panel = new JPanel(new GridLayout(3, 3));

        //create menu
        options = new JMenu("Options");
        menuBar.add(options);

        //create submenu
        newGame = new JMenuItem("New game");
        newGame.addActionListener(this::newGameActionPerformed);
        options.add(newGame);

        //initialize buttons
        initializeButtons();

        //set visibility
        this.setJMenuBar(menuBar);
        this.getContentPane().add(panel);

    }

    private void initializeButtons() {

        //initializing buttons
        for (int i = 0; i < BUTTON_NUMBER; i++) {

            Button button = new Button(i);

            button.setBackground(Color.white);
            button.setBorder(new LineBorder(Color.BLACK));
            button.setFont(new Font("Arial", Font.BOLD, 60));
            button.addActionListener(this);

            buttonList.add(button);
            panel.add(button);

        }

    }

    private void newGameActionPerformed(ActionEvent e) {

        if (e.getSource().equals(newGame)) {

            clearButtons();

        }

    }

    private void clearButtons() {

        for (int i = 0; i < BUTTON_NUMBER; i++)
        {

            buttonList.get(i).setText("");

        }

        move = 0;

    }

    @Override
    public void actionPerformed(ActionEvent e) {

        int index = ((Button) e.getSource()).getIndex();

        if (buttonList.get(index).getText() == "") {

            move++;

            if (var == true) {

                buttonList.get(index).setText("X");
                var = false;

            }
            else {

                buttonList.get(index).setText("0");
                var = true;

            }

            if(!checkWin() && move == 9) {

                JOptionPane.showMessageDialog(null, "TIE!");
                clearButtons();

            }

        }

    }

    private boolean checkWin() {

        String winner = null;
        boolean win = false;

        for (int i = 0; i < 8; i++)
        {
            System.out.println(winIndices[0][2]);
            if (buttonList.get(winIndices[i][0]).getText().equals(buttonList.get(winIndices[i][1]).getText()) &&
                    buttonList.get(winIndices[i][0]).getText().equals(buttonList.get(winIndices[i][2]).getText()) &&
                    !buttonList.get(winIndices[i][0]).getText().equals(""))
            {

                winner = buttonList.get(winIndices[i][0]).getText();
                win = true;

            }

            if (win) {

                JOptionPane.showMessageDialog(null, winner + " is the winner!");
                clearButtons();
                break;

            }

        }

        return win;

    }

    @Override
    public void keyTyped(KeyEvent e) {

    }

    @Override
    public void keyPressed(KeyEvent e) {


    }

    @Override
    public void keyReleased(KeyEvent e) {

    }

    @Override
    public void menuSelected(MenuEvent e) {

    }

    @Override
    public void menuDeselected(MenuEvent e) {

    }

    @Override
    public void menuCanceled(MenuEvent e) {

    }
}
