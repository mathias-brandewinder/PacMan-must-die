module Images

let ``1600`` =
    14, 14,
    let A, B = 0x0, 0xFFED1C24
    [|
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|B; A; B; B; B; A; B; B; B; A; B; B; B; A|]
    [|B; A; B; A; A; A; B; A; B; A; B; A; B; A|]
    [|B; A; B; B; B; A; B; A; B; A; B; A; B; A|]
    [|B; A; B; A; B; A; B; A; B; A; B; A; B; A|]
    [|B; A; B; B; B; A; B; B; B; A; B; B; B; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    |]
let ``200`` =
    14, 14,
    let A, B = 0x0, 0xFFED1C24
    [|
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; B; B; B; A; B; B; B; A; B; B; B; A; A|]
    [|A; A; A; B; A; B; A; B; A; B; A; B; A; A|]
    [|A; B; B; B; A; B; A; B; A; B; A; B; A; A|]
    [|A; B; A; A; A; B; A; B; A; B; A; B; A; A|]
    [|A; B; B; B; A; B; B; B; A; B; B; B; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    |]
let ``400`` =
    14, 14,
    let A, B = 0x0, 0xFFED1C24
    [|
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; B; A; B; A; B; B; B; A; B; B; B; A; A|]
    [|A; B; A; B; A; B; A; B; A; B; A; B; A; A|]
    [|A; B; B; B; A; B; A; B; A; B; A; B; A; A|]
    [|A; A; A; B; A; B; A; B; A; B; A; B; A; A|]
    [|A; A; A; B; A; B; B; B; A; B; B; B; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    |]
let ``800`` =
    14, 14,
    let A, B = 0x0, 0xFFED1C24
    [|
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; B; B; B; A; B; B; B; A; B; B; B; A; A|]
    [|A; B; A; B; A; B; A; B; A; B; A; B; A; A|]
    [|A; B; B; B; A; B; A; B; A; B; A; B; A; A|]
    [|A; B; A; B; A; B; A; B; A; B; A; B; A; A|]
    [|A; B; B; B; A; B; B; B; A; B; B; B; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    |]
let blue =
    14, 14,
    let A, B, C = 0x0, 0xFF2121FF, 0xFFFFB8AE
    [|
    [|A; A; A; A; A; B; B; B; B; A; A; A; A; A|]
    [|A; A; A; B; B; B; B; B; B; B; B; A; A; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; B; B; B; C; C; B; B; C; C; B; B; B; A|]
    [|B; B; B; B; C; C; B; B; C; C; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; C; C; B; B; C; C; B; B; C; C; B; B|]
    [|B; C; B; B; C; C; B; B; C; C; B; B; C; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; A; B; B; B; A; A; B; B; B; A; B; B|]
    [|B; A; A; A; B; B; A; A; B; B; A; A; A; B|]
    |]
let cyand =
    14, 14,
    let A, B, C, D = 0x0, 0xFF00FFDE, 0xFFDEDEDE, 0xFF2121DE
    [|
    [|A; A; A; A; A; B; B; B; B; A; A; A; A; A|]
    [|A; A; A; B; B; B; B; B; B; B; B; A; A; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; B; B; C; C; B; B; B; B; C; C; B; B; A|]
    [|A; B; C; C; C; C; B; B; C; C; C; C; B; A|]
    [|B; B; C; C; C; C; B; B; C; C; C; C; B; B|]
    [|B; B; C; D; D; C; B; B; C; D; D; C; B; B|]
    [|B; B; B; D; D; B; B; B; B; D; D; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; A; B; B; B; A; A; B; B; B; A; B; B|]
    [|B; A; A; A; B; B; A; A; B; B; A; A; A; B|]
    |]
let cyanl =
    14, 14,
    let A, B, C, D = 0x0, 0xFF00FFDE, 0xFFDEDEDE, 0xFF2121DE
    [|
    [|A; A; A; A; A; B; B; B; B; A; A; A; A; A|]
    [|A; A; A; B; B; B; B; B; B; B; B; A; A; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; B; C; C; B; B; B; B; C; C; B; B; B; A|]
    [|A; C; C; C; C; B; B; C; C; C; C; B; B; A|]
    [|A; D; D; C; C; B; B; D; D; C; C; B; B; A|]
    [|B; D; D; C; C; B; B; D; D; C; C; B; B; B|]
    [|B; B; C; C; B; B; B; B; C; C; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; A; B; B; B; A; A; B; B; B; A; B; B|]
    [|B; A; A; A; B; B; A; A; B; B; A; A; A; B|]
    |]
let cyanr =
    14, 14,
    let A, B, C, D = 0x0, 0xFF00FFDE, 0xFFDEDEDE, 0xFF2121DE
    [|
    [|A; A; A; A; A; B; B; B; B; A; A; A; A; A|]
    [|A; A; A; B; B; B; B; B; B; B; B; A; A; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; B; B; B; C; C; B; B; B; B; C; C; B; A|]
    [|A; B; B; C; C; C; C; B; B; C; C; C; C; A|]
    [|A; B; B; C; C; D; D; B; B; C; C; D; D; A|]
    [|B; B; B; C; C; D; D; B; B; C; C; D; D; B|]
    [|B; B; B; B; C; C; B; B; B; B; C; C; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; A; B; B; B; A; A; B; B; B; A; B; B|]
    [|B; A; A; A; B; B; A; A; B; B; A; A; A; B|]
    |]
let cyanu =
    14, 14,
    let A, B, C, D = 0x0, 0xFF00FFDE, 0xFF2121DE, 0xFFDEDEDE
    [|
    [|A; A; A; A; A; B; B; B; B; A; A; A; A; A|]
    [|A; A; A; C; C; B; B; B; B; C; C; A; A; A|]
    [|A; A; D; C; C; D; B; B; D; C; C; D; A; A|]
    [|A; B; D; D; D; D; B; B; D; D; D; D; B; A|]
    [|A; B; D; D; D; D; B; B; D; D; D; D; B; A|]
    [|A; B; B; D; D; B; B; B; B; D; D; B; B; A|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; A; B; B; B; A; A; B; B; B; A; B; B|]
    [|B; A; A; A; B; B; A; A; B; B; A; A; A; B|]
    |]
let eyed =
    14, 14,
    let A, B, C = 0x0, 0xFFDEDEDE, 0xFF2121DE
    [|
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; B; B; A; A; A; A; B; B; A; A; A|]
    [|A; A; B; B; B; B; A; A; B; B; B; B; A; A|]
    [|A; A; B; B; B; B; A; A; B; B; B; B; A; A|]
    [|A; A; B; C; C; B; A; A; B; C; C; B; A; A|]
    [|A; A; A; C; C; A; A; A; A; C; C; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    |]
let eyel =
    14, 14,
    let A, B, C = 0x0, 0xFFDEDEDE, 0xFF2121DE
    [|
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; B; B; A; A; A; A; B; B; A; A; A; A|]
    [|A; B; B; B; B; A; A; B; B; B; B; A; A; A|]
    [|A; C; C; B; B; A; A; C; C; B; B; A; A; A|]
    [|A; C; C; B; B; A; A; C; C; B; B; A; A; A|]
    [|A; A; B; B; A; A; A; A; B; B; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    |]
let eyer =
    14, 14,
    let A, B, C = 0x0, 0xFFDEDEDE, 0xFF2121DE
    [|
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; B; B; A; A; A; A; B; B; A; A|]
    [|A; A; A; B; B; B; B; A; A; B; B; B; B; A|]
    [|A; A; A; B; B; C; C; A; A; B; B; C; C; A|]
    [|A; A; A; B; B; C; C; A; A; B; B; C; C; A|]
    [|A; A; A; A; B; B; A; A; A; A; B; B; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    |]
let eyeu =
    14, 14,
    let A, B, C = 0x0, 0xFF2121DE, 0xFFDEDEDE
    [|
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; B; B; A; A; A; A; B; B; A; A; A|]
    [|A; A; C; B; B; C; A; A; C; B; B; C; A; A|]
    [|A; A; C; C; C; C; A; A; C; C; C; C; A; A|]
    [|A; A; C; C; C; C; A; A; C; C; C; C; A; A|]
    [|A; A; A; C; C; A; A; A; A; C; C; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A; A|]
    |]
let oranged =
    14, 14,
    let A, B, C, D = 0x0, 0xFFFFB847, 0xFFDEDEDE, 0xFF2121DE
    [|
    [|A; A; A; A; A; B; B; B; B; A; A; A; A; A|]
    [|A; A; A; B; B; B; B; B; B; B; B; A; A; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; B; B; C; C; B; B; B; B; C; C; B; B; A|]
    [|A; B; C; C; C; C; B; B; C; C; C; C; B; A|]
    [|B; B; C; C; C; C; B; B; C; C; C; C; B; B|]
    [|B; B; C; D; D; C; B; B; C; D; D; C; B; B|]
    [|B; B; B; D; D; B; B; B; B; D; D; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; A; B; B; B; A; A; B; B; B; A; B; B|]
    [|B; A; A; A; B; B; A; A; B; B; A; A; A; B|]
    |]
let orangel =
    14, 14,
    let A, B, C, D = 0x0, 0xFFFFB847, 0xFFDEDEDE, 0xFF2121DE
    [|
    [|A; A; A; A; A; B; B; B; B; A; A; A; A; A|]
    [|A; A; A; B; B; B; B; B; B; B; B; A; A; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; B; C; C; B; B; B; B; C; C; B; B; B; A|]
    [|A; C; C; C; C; B; B; C; C; C; C; B; B; A|]
    [|A; D; D; C; C; B; B; D; D; C; C; B; B; A|]
    [|B; D; D; C; C; B; B; D; D; C; C; B; B; B|]
    [|B; B; C; C; B; B; B; B; C; C; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; A; B; B; B; A; A; B; B; B; A; B; B|]
    [|B; A; A; A; B; B; A; A; B; B; A; A; A; B|]
    |]
let oranger =
    14, 14,
    let A, B, C, D = 0x0, 0xFFFFB847, 0xFFDEDEDE, 0xFF2121DE
    [|
    [|A; A; A; A; A; B; B; B; B; A; A; A; A; A|]
    [|A; A; A; B; B; B; B; B; B; B; B; A; A; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; B; B; B; C; C; B; B; B; B; C; C; B; A|]
    [|A; B; B; C; C; C; C; B; B; C; C; C; C; A|]
    [|A; B; B; C; C; D; D; B; B; C; C; D; D; A|]
    [|B; B; B; C; C; D; D; B; B; C; C; D; D; B|]
    [|B; B; B; B; C; C; B; B; B; B; C; C; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; A; B; B; B; A; A; B; B; B; A; B; B|]
    [|B; A; A; A; B; B; A; A; B; B; A; A; A; B|]
    |]
let orangeu =
    14, 14,
    let A, B, C, D = 0x0, 0xFFFFB847, 0xFF2121DE, 0xFFDEDEDE
    [|
    [|A; A; A; A; A; B; B; B; B; A; A; A; A; A|]
    [|A; A; A; C; C; B; B; B; B; C; C; A; A; A|]
    [|A; A; D; C; C; D; B; B; D; C; C; D; A; A|]
    [|A; B; D; D; D; D; B; B; D; D; D; D; B; A|]
    [|A; B; D; D; D; D; B; B; D; D; D; D; B; A|]
    [|A; B; B; D; D; B; B; B; B; D; D; B; B; A|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; A; B; B; B; A; A; B; B; B; A; B; B|]
    [|B; A; A; A; B; B; A; A; B; B; A; A; A; B|]
    |]
let p =
    13, 13,
    let A, B = 0x0, 0xFFFFFF00
    [|
    [|A; A; A; A; B; B; B; B; B; A; A; A; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; A; A; A; B; B; B; B; B; A; A; A; A|]
    |]
let pd1 =
    13, 13,
    let A, B = 0x0, 0xFFFFFF00
    [|
    [|A; A; A; A; B; B; B; B; B; A; A; A; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; A; B; B; B; B; B; B|]
    [|B; B; B; B; B; A; A; A; B; B; B; B; B|]
    [|B; B; B; B; B; A; A; A; B; B; B; B; B|]
    [|A; B; B; B; A; A; A; A; A; B; B; B; A|]
    [|A; B; B; B; A; A; A; A; A; B; B; B; A|]
    [|A; A; B; A; A; A; A; A; A; A; B; A; A|]
    [|A; A; A; A; A; A; A; A; A; A; A; A; A|]
    |]
let pd2 =
    13, 13,
    let A, B = 0x0, 0xFFFFFF00
    [|
    [|A; A; A; A; B; B; B; B; B; A; A; A; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; A; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; A; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; A; B; B; B; B; B; B|]
    [|A; B; B; B; B; A; A; A; B; B; B; B; A|]
    [|A; B; B; B; B; A; A; A; B; B; B; B; A|]
    [|A; A; B; B; B; A; A; A; B; B; B; A; A|]
    [|A; A; A; A; B; A; A; A; B; A; A; A; A|]
    |]
let pinkd =
    14, 14,
    let A, B, C, D = 0x0, 0xFFFFB8DE, 0xFFDEDEDE, 0xFF2121DE
    [|
    [|A; A; A; A; A; B; B; B; B; A; A; A; A; A|]
    [|A; A; A; B; B; B; B; B; B; B; B; A; A; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; B; B; C; C; B; B; B; B; C; C; B; B; A|]
    [|A; B; C; C; C; C; B; B; C; C; C; C; B; A|]
    [|B; B; C; C; C; C; B; B; C; C; C; C; B; B|]
    [|B; B; C; D; D; C; B; B; C; D; D; C; B; B|]
    [|B; B; B; D; D; B; B; B; B; D; D; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; A; B; B; B; A; A; B; B; B; A; B; B|]
    [|B; A; A; A; B; B; A; A; B; B; A; A; A; B|]
    |]
let pinkl =
    14, 14,
    let A, B, C, D = 0x0, 0xFFFFAEC9, 0xFFDEDEDE, 0xFF2121DE
    [|
    [|A; A; A; A; A; B; B; B; B; A; A; A; A; A|]
    [|A; A; A; B; B; B; B; B; B; B; B; A; A; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; B; C; C; B; B; B; B; C; C; B; B; B; A|]
    [|A; C; C; C; C; B; B; C; C; C; C; B; B; A|]
    [|A; D; D; C; C; B; B; D; D; C; C; B; B; A|]
    [|B; D; D; C; C; B; B; D; D; C; C; B; B; B|]
    [|B; B; C; C; B; B; B; B; C; C; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; A; B; B; B; A; A; B; B; B; A; B; B|]
    [|B; A; A; A; B; B; A; A; B; B; A; A; A; B|]
    |]
let pinkr =
    14, 14,
    let A, B, C, D = 0x0, 0xFFFFAEC9, 0xFFDEDEDE, 0xFF2121DE
    [|
    [|A; A; A; A; A; B; B; B; B; A; A; A; A; A|]
    [|A; A; A; B; B; B; B; B; B; B; B; A; A; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; B; B; B; C; C; B; B; B; B; C; C; B; A|]
    [|A; B; B; C; C; C; C; B; B; C; C; C; C; A|]
    [|A; B; B; C; C; D; D; B; B; C; C; D; D; A|]
    [|B; B; B; C; C; D; D; B; B; C; C; D; D; B|]
    [|B; B; B; B; C; C; B; B; B; B; C; C; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; A; B; B; B; A; A; B; B; B; A; B; B|]
    [|B; A; A; A; B; B; A; A; B; B; A; A; A; B|]
    |]
let pinku =
    14, 14,
    let A, B, C, D = 0x0, 0xFFFFB8DE, 0xFF2121DE, 0xFFDEDEDE
    [|
    [|A; A; A; A; A; B; B; B; B; A; A; A; A; A|]
    [|A; A; A; C; C; B; B; B; B; C; C; A; A; A|]
    [|A; A; D; C; C; D; B; B; D; C; C; D; A; A|]
    [|A; B; D; D; D; D; B; B; D; D; D; D; B; A|]
    [|A; B; D; D; D; D; B; B; D; D; D; D; B; A|]
    [|A; B; B; D; D; B; B; B; B; D; D; B; B; A|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; A; B; B; B; A; A; B; B; B; A; B; B|]
    [|B; A; A; A; B; B; A; A; B; B; A; A; A; B|]
    |]
let pl1 =
    13, 13,
    let A, B = 0x0, 0xFFFFFF00
    [|
    [|A; A; A; A; B; B; B; B; B; A; A; A; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; A; A; A; B; B; B; B; B; B; B; B; B|]
    [|A; A; A; A; A; A; B; B; B; B; B; B; B|]
    [|A; A; A; A; A; A; A; B; B; B; B; B; B|]
    [|A; A; A; A; A; A; B; B; B; B; B; B; B|]
    [|A; A; A; A; B; B; B; B; B; B; B; B; B|]
    [|A; A; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; A; A; A; B; B; B; B; B; A; A; A; A|]
    |]
let pl2 =
    13, 13,
    let A, B = 0x0, 0xFFFFFF00
    [|
    [|A; A; A; A; B; B; B; B; B; A; A; A; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|A; A; A; A; B; B; B; B; B; B; B; B; B|]
    [|A; A; A; A; A; A; A; B; B; B; B; B; B|]
    [|A; A; A; A; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; A; A; A; B; B; B; B; B; A; A; A; A|]
    |]
let pr1 =
    13, 13,
    let A, B = 0x0, 0xFFFFFF00
    [|
    [|A; A; A; A; B; B; B; B; B; A; A; A; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; A; A|]
    [|B; B; B; B; B; B; B; B; B; A; A; A; A|]
    [|B; B; B; B; B; B; B; A; A; A; A; A; A|]
    [|B; B; B; B; B; B; A; A; A; A; A; A; A|]
    [|B; B; B; B; B; B; B; A; A; A; A; A; A|]
    [|B; B; B; B; B; B; B; B; B; A; A; A; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; A; A; A; B; B; B; B; B; A; A; A; A|]
    |]
let pr2 =
    13, 13,
    let A, B = 0x0, 0xFFFFFF00
    [|
    [|A; A; A; A; B; B; B; B; B; A; A; A; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; A; A; A; A|]
    [|B; B; B; B; B; B; A; A; A; A; A; A; A|]
    [|B; B; B; B; B; B; B; B; B; A; A; A; A|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; A; A; A; B; B; B; B; B; A; A; A; A|]
    |]
let pu1 =
    13, 13,
    let A, B = 0x0, 0xFFFFFF00
    [|
    [|A; A; A; A; A; A; A; A; A; A; A; A; A|]
    [|A; A; B; A; A; A; A; A; A; A; B; A; A|]
    [|A; B; B; B; A; A; A; A; A; B; B; B; A|]
    [|A; B; B; B; A; A; A; A; A; B; B; B; A|]
    [|B; B; B; B; B; A; A; A; B; B; B; B; B|]
    [|B; B; B; B; B; A; A; A; B; B; B; B; B|]
    [|B; B; B; B; B; B; A; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; A; A; A; B; B; B; B; B; A; A; A; A|]
    |]
let pu2 =
    13, 13,
    let A, B = 0x0, 0xFFFFFF00
    [|
    [|A; A; A; A; B; A; A; A; B; A; A; A; A|]
    [|A; A; B; B; B; A; A; A; B; B; B; A; A|]
    [|A; B; B; B; B; A; A; A; B; B; B; B; A|]
    [|A; B; B; B; B; A; A; A; B; B; B; B; A|]
    [|B; B; B; B; B; B; A; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; A; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; A; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; A; A; A; B; B; B; B; B; A; A; A; A|]
    |]
let redd =
    14, 14,
    let A, B, C, D = 0x0, 0xFFFF0000, 0xFFDEDEDE, 0xFF2121DE
    [|
    [|A; A; A; A; A; B; B; B; B; A; A; A; A; A|]
    [|A; A; A; B; B; B; B; B; B; B; B; A; A; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; B; B; B; B; B; B; B; B; B; B; B; B; A|]
    [|A; B; B; C; C; B; B; B; B; C; C; B; B; A|]
    [|A; B; C; C; C; C; B; B; C; C; C; C; B; A|]
    [|B; B; C; C; C; C; B; B; C; C; C; C; B; B|]
    [|B; B; C; D; D; C; B; B; C; D; D; C; B; B|]
    [|B; B; B; D; D; B; B; B; B; D; D; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; A; B; B; B; A; A; B; B; B; A; B; B|]
    [|B; A; A; A; B; B; A; A; B; B; A; A; A; B|]
    |]
let redl =
    14, 14,
    let A, B, C, D = 0x0, 0xFFFF0000, 0xFFDEDEDE, 0xFF2121DE
    [|
    [|A; A; A; A; A; B; B; B; B; A; A; A; A; A|]
    [|A; A; A; B; B; B; B; B; B; B; B; A; A; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; B; C; C; B; B; B; B; C; C; B; B; B; A|]
    [|A; C; C; C; C; B; B; C; C; C; C; B; B; A|]
    [|A; D; D; C; C; B; B; D; D; C; C; B; B; A|]
    [|B; D; D; C; C; B; B; D; D; C; C; B; B; B|]
    [|B; B; C; C; B; B; B; B; C; C; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; A; B; B; B; A; A; B; B; B; A; B; B|]
    [|B; A; A; A; B; B; A; A; B; B; A; A; A; B|]
    |]
let redr =
    14, 14,
    let A, B, C, D = 0x0, 0xFFFF0000, 0xFFDEDEDE, 0xFF2121DE
    [|
    [|A; A; A; A; A; B; B; B; B; A; A; A; A; A|]
    [|A; A; A; B; B; B; B; B; B; B; B; A; A; A|]
    [|A; A; B; B; B; B; B; B; B; B; B; B; A; A|]
    [|A; B; B; B; C; C; B; B; B; B; C; C; B; A|]
    [|A; B; B; C; C; C; C; B; B; C; C; C; C; A|]
    [|A; B; B; C; C; D; D; B; B; C; C; D; D; A|]
    [|B; B; B; C; C; D; D; B; B; C; C; D; D; B|]
    [|B; B; B; B; C; C; B; B; B; B; C; C; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; A; B; B; B; A; A; B; B; B; A; B; B|]
    [|B; A; A; A; B; B; A; A; B; B; A; A; A; B|]
    |]
let redu =
    14, 14,
    let A, B, C, D = 0x0, 0xFFFF0000, 0xFF2121DE, 0xFFDEDEDE
    [|
    [|A; A; A; A; A; B; B; B; B; A; A; A; A; A|]
    [|A; A; A; C; C; B; B; B; B; C; C; A; A; A|]
    [|A; A; D; C; C; D; B; B; D; C; C; D; A; A|]
    [|A; B; D; D; D; D; B; B; D; D; D; D; B; A|]
    [|A; B; D; D; D; D; B; B; D; D; D; D; B; A|]
    [|A; B; B; D; D; B; B; B; B; D; D; B; B; A|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; B; B; B; B; B; B; B; B; B; B; B; B|]
    [|B; B; A; B; B; B; A; A; B; B; B; A; B; B|]
    [|B; A; A; A; B; B; A; A; B; B; A; A; A; B|]
    |]
let nameToValue =
    [
    "1600", ``1600``
    "200", ``200``
    "400", ``400``
    "800", ``800``
    "blue", blue
    "cyand", cyand
    "cyanl", cyanl
    "cyanr", cyanr
    "cyanu", cyanu
    "eyed", eyed
    "eyel", eyel
    "eyer", eyer
    "eyeu", eyeu
    "oranged", oranged
    "orangel", orangel
    "oranger", oranger
    "orangeu", orangeu
    "p", p
    "pd1", pd1
    "pd2", pd2
    "pinkd", pinkd
    "pinkl", pinkl
    "pinkr", pinkr
    "pinku", pinku
    "pl1", pl1
    "pl2", pl2
    "pr1", pr1
    "pr2", pr2
    "pu1", pu1
    "pu2", pu2
    "redd", redd
    "redl", redl
    "redr", redr
    "redu", redu
    ]