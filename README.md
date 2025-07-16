
---

# Báo cáo tiểu luận 

![LogoKhoa](https://github.com/user-attachments/assets/a41f75e9-98de-4dc9-8738-844b3f6491ac)



## **Nhóm 11 **

### **1. Cài đặt (How to Install)**
1. Clone project từ GitHub: `https://github.com/meaicap/LTG-G11.git`.
2. Mở project bằng Unity.

---

### **2. Hướng dẫn sử dụng (How to Run)**
1. **Play:** Ấn play để lựa chọn chơi: New Game, Quit Game, Back.
2. **New Game:** 
   - Vô màn chơi đầu.
3. **Thanh máu và mạng:**  
   -Thanh máu bên trái dễ quan sát. 
   - Khi nhặt gem trên đường cứ 10 gem là được 1 mạng hiển thị bên trên  
4. **Hoàn thành:** Vượt qua các màn chơi. Sau khi kết thúc sẽ hiển thị YOU WIN và bạn có thể lựa chọn MAIN MENU hoặc chơi lại màn hiện tại.

---

### **3. Mô tả đề tài**
Báo cáo này trình bày chi tiết quá trình phát triển "High Jump Adventure", một trò chơi platformer 2D có nhịp độ nhanh. Trò chơi tập trung vào một nhân vật chính linh hoạt vượt qua các cấp độ khác nhau, vượt chướng ngại vật và tránh hoặc tấn công quái vật. Nó nhấn mạnh phản xạ nhanh, điều khiển chính xác và nhảy chiến lược. Dự án sử dụng Unity để phát triển và Visual Studio Code để viết mã C#


#### **Công nghệ sử dụng:**
1. **Unity:** 
2. **Visual Studio** 
---

### **4. Nhiệm vụ các thành viên**
**Phạm Trọng Toàn (Nhóm Trưởng)**: AudioManager + Sound, HealthManager, New Game, Item Collect.

**Trịnh Huy Hoàng**: Di chuyển quái vật, GameManager.

**Lê Hồng Quân**: Di chuyển nhân vật, Pause.

**Nguyễn Hữu Tín**: Vẽ map, Data, Animation, Victory.

**Nguyễn Minh Tâm**: Vẽ map, UI Controller, Load Map 2 & 3.

---


### **5. Chức năng đã xây dựng được **
Quản lý game Menu (Start, Game Over, Quit): Điều hướng chính, hiển thị menu chính khi khởi động, Game Over khi thua, sử dụng UI của Unity.
Điều khiển nhân vật (Run, Jump, Attack): Cho phép di chuyển trái/phải, nhảy (giữ lâu để nhảy cao hơn), tấn công quái vật bằng cách nhảy lên đầu. Lập trình bằng Rigidbody2D, Animator, sự kiện đầu vào Unity.
Quản lý các vật cản (Take Damage, Move, Attack): Lập trình hành vi riêng cho chướng ngại vật và kẻ địch. Xử lý sự kiện "Take Damage" (mất kim cương hoặc mất mạng). Sử dụng Collider2D và script AI đơn giản.
Quản lý các màn chơi: Tổ chức tiến trình chơi theo từng cấp độ, mỗi màn là một scene riêng biệt. Thiết kế thủ công bố cục địa hình, vật phẩm, quái vật. Vượt qua màn để mở khóa màn tiếp theo, khu vực kết thúc bằng trận đánh trùm.

### **7. Hình ảnh minh họa**
#### **Gameplay:**
- **Game:**  
  !<img width="836" height="415" alt="image" src="https://github.com/user-attachments/assets/f4e8983c-1861-4072-90ff-b7dd2a07948d" />
  !<img width="1003" height="284" alt="image" src="https://github.com/user-attachments/assets/1aa3ea5d-6ec5-46bd-a32b-2aafd471888a" /> 
  !<img width="741" height="366" alt="image" src="https://github.com/user-attachments/assets/e72592a0-f5cd-4756-83d7-90c28081564b" />
  !<img width="1226" height="555" alt="image" src="https://github.com/user-attachments/assets/581524db-0fab-4529-9c37-5e1a40c1d793" />
  
 #### **Player:**
 !<img width="33" height="32" alt="image" src="https://github.com/user-attachments/assets/a1febc8d-e800-4ade-a217-7ea7ae2f73e1" />

#### **Enemy Bosses:**

  !<img width="41" height="38" alt="image" src="https://github.com/user-attachments/assets/17075617-5543-494b-a1f4-684b83ba78ed" />
  !<img width="53" height="57" alt="image" src="https://github.com/user-attachments/assets/dad21479-acb5-4c8f-8cb3-3f2155514865" />
  !<img width="35" height="32" alt="image" src="https://github.com/user-attachments/assets/9307d977-3c2b-45b1-bcdf-720512c18f4c" />
  !<img width="33" height="26" alt="image" src="https://github.com/user-attachments/assets/39265a6e-2864-4f83-a84c-5303d777494a" />



---


