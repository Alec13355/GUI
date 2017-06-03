//
//  LoginController.swift
//  Chat_In_Swift
//
//  Created by Alec Harrison on 5/22/17.
//  Copyright © 2017 Meráki Studios. All rights reserved.
//

import UIKit

class LoginController: UIViewController {
    
    let inputsContainerView: UIView = {
        let view = UIView()
        view.backgroundColor = UIColor.white
        view.translatesAutoresizingMaskIntoConstraints = false
        view.layer.cornerRadius = 5
        view.layer.masksToBounds = true
        return view
        
    }()
    
    override func viewDidLoad() {
        super.viewDidLoad()

        view.backgroundColor = UIColor(red: 255/255, green: 0/255, blue: 0/255, alpha: 1)
        
        view.addSubview(inputsContainerView)
        
        setupInputsContainer()
        
        
    }
    
    func setupInputsContainer(){
        inputsContainerView.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true;
        inputsContainerView.centerYAnchor.constraint(equalTo: view.centerYAnchor).isActive = true;
        inputsContainerView.widthAnchor.constraint(equalTo: view.widthAnchor, constant: -24).isActive = true;
        inputsContainerView.heightAnchor.constraint(equalToConstant: 150).isActive = true;
    }
}

extension UIColor{

    convenience init(r: CGFloat, g: CGFloat, b: CGFloat){
        self.init(red: r/255, green: g/255, blue: b/255, alpha: 1)
    }
    
}