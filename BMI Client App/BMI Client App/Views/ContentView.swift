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
    
    @State private var healthData: Health?
    
    class SheetMananger: ObservableObject {
        @Published var showSheet = false
        @Published var color: Color = Color.blue
    }
    
    @StateObject var sheetManager = SheetMananger()
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
        .sheet(isPresented: $sheetManager.showSheet) {
            NavigationView {
                if let healthData = healthData {
                    ResultView(healthData: healthData, color: sheetManager.color)
                        .navigationBarItems(leading: Button(action: dismiss) {
                            Image(systemName: "chevron.left")
                                .imageScale(.large)
                                .foregroundColor(.black)
                        })
                }
            }
        }
    }
    
    private func dismiss() {
        sheetManager.showSheet.toggle()
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
                
                if healthData.bmi < 18 {
                    sheetManager.color = Color.blue
                } else if healthData.bmi < 25 {
                    sheetManager.color = Color.green
                } else if healthData.bmi <= 30 {
                    sheetManager.color = Color.purple
                } else {
                    sheetManager.color = Color.red
                }
                
                sheetManager.showSheet.toggle()
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
