//
//  Health.swift
//  BMI Client App
//
//  Created by Hiroto Aoyama on 2023/06/25.
//

import Foundation

struct Health: Codable {
    let bmi: Double
    let risk: String
    let more: [String]
}
