//
//  ResultView.swift
//  BMI Client App
//
//  Created by Hiroto Aoyama on 2023/06/26.
//

import SwiftUI

struct ResultView: View {
    let healthData: Health
    
    var body: some View {
        VStack {
            Text("BMI: \(String(format: "%.2f", healthData.bmi))")
                .font(.title)
                .padding()
            
            Text("Risk: \(healthData.risk)")
                .font(.title)
                .padding()
            
            Text("More Information:")
                .font(.subheadline)
                .padding(.top)
            
            VStack(alignment: .leading, spacing: 8) {
                ForEach(healthData.more, id: \.self) { infoURL in
                    Text(infoURL)
                        .padding(.horizontal)
                        .foregroundColor(.blue)
                        .underline()
                        .onTapGesture {
                            if let url = URL(string: infoURL) {
                                UIApplication.shared.open(url)
                            }
                        }
                }
            }
            .font(.caption)
        }
    }
}

struct ResultView_Previews: PreviewProvider {
    static var previews: some View {
        let healthData = Health(bmi: 39.05555555555555, risk: "You are obese :(", more: [
            "https://www.cdc.gov/healthyweight/assessing/bmi/index.html",
            "https://www.nhlbi.nih.gov/health/educational/lose_wt/index.htm",
            "https://www.ucsfhealth.org/education/body_mass_index_tool/"
        ])
        ResultView(healthData: healthData)
    }
}
