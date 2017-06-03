//
//  ViewController.swift
//  Chat_In_Swift
//
//  Created by Alec Harrison on 5/22/17.
//  Copyright © 2017 Meráki Studios. All rights reserved.
//

import UIKit

class ViewController: UITableViewController {

    override func viewDidLoad() {
        super.viewDidLoad()
       
        navigationItem.leftBarButtonItem = UIBarButtonItem(title: "Logout", style: .plain, target: self, action: #selector(handleLogout))
    }
    
    func handleLogout(){
        let loginController = LoginController()
        present(loginController, animated: true, completion: nil)
    }

}

