import os
import PyPDF2

def extract_text_from_pdf(pdf_file):
    with open(pdf_file, 'rb') as f:
        reader = PyPDF2.PdfReader(f)
        text = ''
        for page_num in range(len(reader.pages)):
            page = reader.pages[page_num]
            text += page.extract_text()
    return text

def main():
    pdf_file = 'datafile.pdf'  # Change this to the path of your PDF file
    output_file = 'data.txt'

    if os.path.exists(pdf_file):
        text = extract_text_from_pdf(pdf_file)
        with open(output_file, 'a') as f:
            f.write(text)
        print(f"Text extracted from '{pdf_file}' and appended to '{output_file}'")
    else:
        print(f"Error: '{pdf_file}' does not exist.")

if __name__ == "__main__":
    main()
