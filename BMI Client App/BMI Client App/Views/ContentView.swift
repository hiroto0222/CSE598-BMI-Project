//
//  ContentView.swift
//  BMI Client App
//
//  Created by Hiroto Aoyama on 2023/06/25.
//

import SwiftUI

struct ContentView: View {
    @State private var heightText = ""
    @State private var weightText = ""
    @State private var errorText = ""
    
    @State private var healthData: Health? = nil
    @State private var isShowResult = false
    
    private let healthController = HealthController()
    
    var body: some View {
        VStack {
            Text("BMI API")
                .font(.title)
            
            TextField("Enter weight", text: $weightText)
                .textFieldStyle(RoundedBorderTextFieldStyle())
                .padding()
            
            TextField("Enter height", text: $heightText)
                .textFieldStyle(RoundedBorderTextFieldStyle())
                .padding()
            
            Button(action: getHealth) {
                Text("Get Health")
            }
            .padding()
            
            Text(errorText)
                .padding()
                .multilineTextAlignment(.center)
        }
        .padding()
    }
    
    private func getHealth() {
        guard let weight = Double(weightText), let height = Double(heightText)
        else {
            errorText = "Invalid input, weight and height must be numbers"
            return
        }
        
        healthController.getHealth(weight: weight, height: height) { healthData, error in
            if let error = error {
                errorText = "Error: \(error.localizedDescription)"
                return
            }
            
            if let healthData = healthData {
                self.healthData = healthData
                isShowResult = true
            } else {
                errorText = "Failed to obtain data"
            }
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
