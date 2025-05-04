def menu():
    print("Please enter one of the options (1 to 8):")
    print("1. Create account")
    print("2. Deposit money")
    print("3. Withdraw money")
    print("4. Check Balance in account")
    print("5. Close account")
    print("6. Display all accounts holder list")
    print("7. Total Balance in the Bank")
    print("8. Quit")
    option = (input()) #בחירת אופציה מתוך תפריט
    return (option)

def create_account(bank_accounts):
    print("1. Create account:")
    id = int(input("Enter your id here:"))
    while len(str(id)) != 9:   #תנאי להזנת מס' תעודת זהות אורך של 9 ספרות
        id = int(input("Make sure you enter your id correctly\nEnter your id here:"))
    for account_num in bank_accounts: #בדיקה שלקוח אינו קיים במאגר
        if id == bank_accounts[account_num]['id']: #כאשר ערך הת"ז קיים במילון פונקציה תחזיר הודעה ותפסיק
            return (print("Account is already registered\nCan not create another account"))
    import random
    new_account_num = random.randrange(1000, 9999)    #יצירת מס' לקוח חדש רנדומלי בעל 4 ספרות
    while True: #בדיקה שהמס' לא קיים כבר
        if new_account_num in bank_accounts: #במידה וקיים- יצירת מס חדש
            import random
            new_account_num = random.randrange(1000, 9999)
        else:   #מס' לא קיים- שמירת המס שיצרנו והמשך פקודות בפונ'
            break
    balance = 0   #איפוס סכום הכסף בבנק ללקוח חדש
    first_name = input(str("Enter your first name here:"))
    while True:
        if len(first_name) <= 1: #בדיקה שהשם לא ריק
            first_name = input(str("Make sure your name is correct\nEnter your first name here:"))
        is_english = False
        for chr in first_name:
            if (ord(chr) >= ord('A') and ord(chr) <= ord('Z')) or (ord(chr) >= ord('a') and ord(chr) <= ord('z')): #מעבר על כל אות ואות לבדיקה האם היא באותיות באנגלית (גדולות או קטונות)
                is_english = True
                break
        if is_english == False: #במידה והאותיות לא באנגלית נבקש להקיש שוב את השם
            first_name = input(str("Make sure your name is containing english letters only\nEnter your first name here:"))
        else:
            break
    first_name = first_name.lower()  # שינוי כלל האותיות לקטנות
    first_name = first_name.capitalize()  # הפיכת אות ראשונה לגדולה
    last_name = input(str("Enter your last name here:"))
    while True:
        if len(last_name) <= 1:  # בדיקה שהשם לא ריק
            last_name = input(str("Make sure your name is correct\nEnter your last name here:"))
        is_english = False
        for chr in last_name:
            if (ord(chr) >= ord('A') and ord(chr) <= ord('Z')) or (ord(chr) >= ord('a') and ord(chr) <= ord('z')):  # מעבר על כל אות ואות לבדיקה האם היא באותיות באנגלית (גדולות או קטונות)
                is_english = True
                break
        if is_english == False:  # במידה והאותיות לא באנגלית נבקש להקיש שוב את השם
            last_name = input(str("Make sure your name is containing english letters only\nEnter your last name here:"))
        else:
            break
    last_name = last_name.lower()  #שינוי כלל האותיות לקטנות
    last_name = last_name.capitalize()   #הפיכת אות ראשונה לגדולה
    date_of_birth = input(str("Enter your date of birth by the format DD/MM/YYYY here:"))
    while True:
        if len(date_of_birth) != len("DD/MM/YYYY"):  # בדיקה שאורך תאריך הלידה נכון
            date_of_birth = input(str("Make sure you didn't forget a number ot typed more numbers\nEnter your date of birth by the format DD/MM/YYYY here:"))
        if date_of_birth[2] and date_of_birth[5] != '/':  # בדיקה שהתאריך מופרד ע"י מקפים
            date_of_birth = input(str("Enter your date of birth again with / dividing day, month and year here:"))
        if int(date_of_birth[0:2]) <= 0 or int(date_of_birth[0:2]) > 31:  # בדיקה שהזנת הימים בין הערכים 1-31
            date_of_birth = input(str("Make sure you typed the day of birth in range(1-31)\nEnter your date of birth again:"))
        if int(date_of_birth[3:5]) <= 0 or int(date_of_birth[3:5]) > 12:  # בדיקה שהזנת החודשים בין הערכים 1-12
            date_of_birth = input(str("Make sure you typed the month of birth in range(1-12)\nEnter your date of birth again:"))
        if int(date_of_birth[6:10]) > 2008:  # תנאי גיל מעל 16 ליצירת חשבון
            return (print("Can't open an account if you are under 16 years old"))
            break
        if int(date_of_birth[6:10]) == 2008 and int(date_of_birth[3:5]) > 3: #תנאי גיל מעל 16 ליצירת חשבון עבור מי שנולד בשנה שבה בני 16
            return (print("Can't open an account if you are under 16 years old"))
            break
        else:
            break
    email = input(str("Enter your email here:"))
    while True:
        for chr in email:
            if '@' not in email: #בדיקה שקיים @ במייל
                email = input(str("Don't forget @ sign\nEnter your email here:"))
            else:
                break
        if email[0] == '@': #בדיקה ש@ לא באות ראשונה
            email = input(str("Make sure your email is correct\nEnter your email here:"))
        elif email[-4:] != '.com': #בדיקה שהמייל מסתיים ב .com
            email = input(str("Make sure your email is ending with .com\nEnter your email here:"))
        else:
            break
    bank_accounts[new_account_num]= {'id': id, 'first_name': first_name, 'last_name': last_name, 'date_of_birth': date_of_birth, 'email': email, 'balance': balance} #יצירת המילון
    print(f"Your account has been created successfully\naccount number: {new_account_num}\nid: {id}\nfirst_name: {first_name}\nlast_name: {last_name}\ndate_of_birth: {date_of_birth}\nemail: {email}")

def deposit_money(bank_accounts):
    print("2. Deposit money:")
    entered_account_num = int(input("Enter your account number here:"))
    entered_deposit_money = float(input("Enter an ammount of money to deposit here:"))
    if entered_account_num in bank_accounts: #בדיקה שמס לקוח קיים
        bank_accounts[entered_account_num]['balance'] += entered_deposit_money #הוספת הסכום הרצוי במידה והלקוח קיים
    else:
        return (print("Invalid account number\nPlease create an account"))  #כאשר לא קיים לקוח לא תבוצע הפקדה
    print(f"Deposit has been deposited succesfuly\naccount number: {entered_account_num}\nid : {bank_accounts[entered_account_num]['id']}\nbalance: {bank_accounts[entered_account_num]['balance']}")

def authenticate_user(bank_accounts, entered_account_num):
    print("This is an authentication check")
    autheticate_id = int(input("Please enter your id here:"))
    autheticate_date_of_birth = input(str("Please enter your date of birth by the format DD/MM/YYYY here:"))
    if autheticate_date_of_birth == bank_accounts[entered_account_num]['date_of_birth'] and autheticate_id == bank_accounts[entered_account_num]['id']: # בדיקה שאכן מס' ת"ז ותאריך לידה מתאימים לנתוני הלקוח
        return True
    else:
        return False

def withdraw_money(bank_accounts):
    print("3. Withdraw money:")
    entered_account_num = int(input("Enter your account number here:"))
    entered_withdraw_money = float(input("Enter an ammount of money to withdraw here:"))
    if authenticate_user(bank_accounts, entered_account_num):  #קריאה לפונקציה שהוגדרה קודם לבדיקת אימות משתמש- תנאי אם יוצא TRUE
        bank_accounts[entered_account_num]['balance'] -= entered_withdraw_money
        if bank_accounts[entered_account_num]['balance'] < -1000: #תנאי מסגרת מינוס
            bank_accounts[entered_account_num]['balance'] += entered_withdraw_money
            print("The amount of withdraw money is beyond the minimum amount of balance\nCan not withdraw money from your account")
        else:
            print(f"Withdrawal successful\naccount number: {entered_account_num}\nid :{bank_accounts[entered_account_num]['id']}\nYour current balace is: {bank_accounts[entered_account_num]['balance']}\n")
    else:   #במידה ובדיקת אימות נכשלת
        return (print("The authentication was failed\nCan not withdraw money"))

def check_balance(bank_accounts):
    print("4. Check Balance in account:")
    entered_account_num = int(input("Enter your account number here:"))
    if entered_account_num in bank_accounts: #בדיקת קיום לקוח במאגר והדפסת נתוניו כאשר קיים
        print(f"account number: {entered_account_num}\nid: {bank_accounts[entered_account_num]['id']}\nfirst_name: {bank_accounts[entered_account_num]['first_name']}\nlast_name: {bank_accounts[entered_account_num]['last_name']}\ndate_of_birth: {bank_accounts[entered_account_num]['date_of_birth']}\nemail: {bank_accounts[entered_account_num]['email']}\nbalance: {bank_accounts[entered_account_num]['balance']}")
    else:
        return (print("Invalid account number\nPlease create an account"))  #כאשר לא קיים לקוח לא תבוצע הדפסת פרטים

def close_account(bank_accounts):
    print("5. Close account:")
    entered_account_num = int(input("Enter the account number that you want to close here:"))
    if authenticate_user(bank_accounts,entered_account_num):  # קריאה לפונקציה שהוגדרה קודם לבדיקת אימות משתמש- תנאי אם יוצא TRUE
        if bank_accounts[entered_account_num]['balance'] > 0: #בדיקה אם קיימת יתרה בחשבון
            print(f"Your account has been closed successfully\nYour balance: {bank_accounts[entered_account_num]['balance']}")
            del bank_accounts[entered_account_num]
        else:
            print("Your account has been closed successfully")
            del bank_accounts[entered_account_num]
    else:
        print("The authentication was failed\nCan not close the account")

def display_all_accounts(bank_accounts):
    print("6. Display all accounts holder list:")
    print("Bank accounts:")
    for account_num in bank_accounts:
        print(f"account number: {account_num} first name: {bank_accounts[account_num]['first_name']} last name: {bank_accounts[account_num]['last_name']} balance: {bank_accounts[account_num]['balance']}")

def total_bank_balance(bank_accounts):
    print("7. Total Balance in the Bank")
    total_balance = 0
    for account_num in bank_accounts:
        total_balance += (bank_accounts[account_num]['balance'])
    print(f"The total bank balance is:{total_balance}")

def main():
    bank_accounts = {}  # יצירת מילון ריק ללקוחות הבנק
    account_num = {}  # יצירת מילון ריק למס' חשבון
    while True:
        choice = menu()
        if choice == '1':
            create_account(bank_accounts)
        elif choice == '2':
            deposit_money(bank_accounts)
        elif choice == '3':
            withdraw_money(bank_accounts)
        elif choice == '4':
            check_balance(bank_accounts)
        elif choice == '5':
            close_account(bank_accounts)
        elif choice == '6':
            display_all_accounts(bank_accounts)
        elif choice == '7':
            total_bank_balance(bank_accounts)
        elif choice == '8':
            print("Exiting the system")
            break
        else:
            print("Invalid choice.please enter a number from 1 to 8")
if __name__ == '__main__':
    main()


