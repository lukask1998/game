public static void main(String[] args) {

        javax.swing.SwingUtilities.invokeLater(new Runnable() {
            public void run() {
                createGUI();
            }
        });

    }

    private static void createGUI()
    {
        //create frame
        Frame frame = new Frame();
        maximiseFrame(frame);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        //display window
        frame.pack();
        frame.setVisible(true);
    }

    private static void maximiseFrame(JFrame frame) {

        //frame settings
        frame.setDefaultCloseOperation(frame.EXIT_ON_CLOSE);
        frame.setPreferredSize(new Dimension(600, 600));
        frame.setResizable(false);
        //frame.setExtendedState(frame.getExtendedState() | frame.MAXIMIZED_BOTH);

    }
