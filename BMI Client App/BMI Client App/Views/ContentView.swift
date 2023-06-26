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
            Spacer()
            
            Text("BMI Calculator")
                .font(.title)
            
            Spacer()
            
            TextField("Enter weight (lbs)", text: $weightText)
                .textFieldStyle(RoundedBorderTextFieldStyle())
                .padding()
            
            TextField("Enter height (in)", text: $heightText)
                .textFieldStyle(RoundedBorderTextFieldStyle())
                .padding()
                        
            Text(errorText)
                .foregroundColor(.red)
                .padding()
                .multilineTextAlignment(.center)
            
            Spacer()
                        
            Button(action: getHealth) {
                Text("Get Health")
                    .font(.title2)
                    .foregroundColor(Color(UIColor.white))
                    .padding()
                    .background(Color(UIColor.systemGreen))
                    .cornerRadius(16)
            }
            .padding()
        }
        .padding()
        .sheet(isPresented: $isShowResult) {
            NavigationView {
                if let healthData = healthData {
                    ResultView(healthData: healthData)
                        .navigationBarItems(leading: Button(action: dismiss) {
                            Image(systemName: "chevron.left")
                                .imageScale(.large)
                                .foregroundColor(.blue)
                        })
                }
            }
        }
    }
    
    private func dismiss() {
        isShowResult = false
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
                return
            }
            
            errorText = ""
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
